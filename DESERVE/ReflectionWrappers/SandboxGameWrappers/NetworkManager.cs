using DESERVE.Managers;
using Sandbox.ModAPI;
using SteamSDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	public class NetworkManager : ReflectionClassWrapper
	{
		#region Fields
		private const string Class = "9CDBE03D49929CA686F49B66EE307DD7";

		private ReflectionMethod m_registerOnPlayerConnected;
		private ReflectionMethod m_registerOnPlayerDisconnected;
		private ReflectionMethod m_registerOnChatMessage;
		private ReflectionMethod m_sendStruct;
		#endregion

		#region Events
		public delegate void ChatMessageEventHandler(ulong remoteUserId, String message, ChatEntryTypeEnum entryType);
		public event ChatMessageEventHandler OnChatMessage;

		public delegate void PlayerEventHandler(ulong steamId);
		public event PlayerEventHandler OnPlayerConnected;
		public event PlayerEventHandler OnPlayerDisconnected;
		#endregion

		#region Properties
		public override String ClassName { get { return "NetworkManager"; } }
		public override String AssemblyName { get { return "Sandbox.Game"; } }

		public Object Instance { get { return SandboxGameWrapper.SteamNetworkWrapper.NetworkManagerInstance; } }
		#endregion

		#region Methods
		public NetworkManager(Assembly Assembly, String Namespace)
			: base(Assembly, Namespace, Class)
		{
			SetupReflection();
			OnChatMessage += NetworkManager_OnChatMessage;
		}

		void NetworkManager_OnChatMessage(ulong remoteUserId, String message, ChatEntryTypeEnum entryType)
		{
			if (!ProcessChatCommand(remoteUserId, message))
			{
				LogManager.ChatLog.WriteLineAndConsole(String.Format("{0}: {1}", GetName(remoteUserId), message));
			}
		}

		private void SetupReflection()
		{
			try
			{
				m_registerOnPlayerConnected = new ReflectionMethod("F9966FB125828848AF95AC147D94AD4D", Class, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			try
			{
				m_registerOnPlayerDisconnected = new ReflectionMethod("CB2189695DC3B1F24683636C24A9C554", Class, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			try
			{
				m_registerOnChatMessage = new ReflectionMethod("8A73057A206BFCA00EC372183441891A", Class, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			try
			{
				m_sendStruct = new ReflectionMethod("6D24456D3649B6393BA2AF59E656E4BF", Class, m_classType);
			}
			catch (ArgumentException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
		}

		public override void Init()
		{
			RegisterOnPlayerConnectedAction(PlayerConnected);
			RegisterOnPlayerDisconnectedAction(PlayerDisconnected);
			RegisterOnChatMessageAction(ChatMessageRecieved);
		}

		private void RegisterOnPlayerConnectedAction(Action<ulong> action)
		{
			m_registerOnPlayerConnected.Call(Instance, new Object[] { action });
		}

		private void RegisterOnPlayerDisconnectedAction(Action<ulong, ChatMemberStateChangeEnum> action)
		{
			m_registerOnPlayerDisconnected.Call(Instance, new Object[] { action });
		}

		private void RegisterOnChatMessageAction(Action<ulong, string, ChatEntryTypeEnum> action)
		{
			m_registerOnChatMessage.Call(Instance, new Object[] { action });
		}

		private void PlayerConnected(ulong steamId)
		{
			if (OnPlayerConnected != null)
			{
				// MyAPIGateway.Players updates after this event.
				OnPlayerConnected(steamId);
			}
		}

		private void PlayerDisconnected(ulong steamId, ChatMemberStateChangeEnum stateChange)
		{
			if (OnPlayerDisconnected != null)
			{
				// MyAPIGateway.Players updates before this event.
				OnPlayerDisconnected(steamId);
			}
		}

		private void ChatMessageRecieved(ulong remoteUserId, string message, ChatEntryTypeEnum entryType)
		{
			if (OnChatMessage != null)
			{
				OnChatMessage(remoteUserId, message, entryType);
			}
		}

		private bool ProcessChatCommand(ulong remoteUserId, String message)
		{
			if (String.IsNullOrEmpty(message))
			{
				return false;
			}

			String[] messageWords = message.Split(' ');

			if (!String.IsNullOrEmpty(messageWords[0]))
			{
				if (messageWords[0].Substring(0, 1) == "/")
				{
					String Command = messageWords[0].ToLowerInvariant();

					//  TODO: Expand to actually have chat commands.
					if (Command == "/save")
					{
						//ServerInstance.Instance.Save();
					}
				}
			}

			return false;
		}

		public String GetName(ulong steamId)
		{
			if (steamId == 0)
			{
				return "Server";
			}

			List<IMyPlayer> players = new List<IMyPlayer>();
			MyAPIGateway.Players.GetPlayers(players);
			foreach (IMyPlayer player in players)
			{
				if (player.SteamUserId == steamId)
				{
					return player.DisplayName;
				}
			}

			return steamId.ToString();
		}

		public void SendChatMessage(String message, ulong steamId = 0)
		{
			Object ChatMessage = SandboxGameWrapper.ChatMessageStruct.CreateStruct(message);

			if (steamId == 0)
			{
				List<IMyPlayer> players = new List<IMyPlayer>();
				MyAPIGateway.Players.GetPlayers(players);

				if (OnChatMessage != null)
				{
					OnChatMessage(0, message, ChatEntryTypeEnum.ChatMsg);
				}

				if (players.Count > 0)
				{
					foreach (IMyPlayer player in players)
					{
						SendStruct(player.SteamUserId, ChatMessage);
					}
				}
			}
			else
			{
				SendStruct(steamId, ChatMessage);
				OnChatMessage(0, message, ChatEntryTypeEnum.ChatMsg);
			}
		}

		private void SendStruct(ulong remoteUserId, Object data)
		{
			Type[] types =
			{
				remoteUserId.GetType(),
				data.GetType().MakeByRefType(),
			};
			m_sendStruct.Call(Instance, new object[] { remoteUserId, data }, types, data.GetType());
		}
		#endregion
	}
}
