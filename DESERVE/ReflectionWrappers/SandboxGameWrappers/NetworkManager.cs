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

		private ReflectionMethod m_registerOnChatMessage;
		private ReflectionMethod m_sendStruct;
		#endregion

		#region Events
		public delegate void ChatMessageEventHandler(ulong remoteUserId, String message, ChatEntryTypeEnum entryType);
		public event ChatMessageEventHandler OnChatMessage;
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
				LogManager.ChatLog.WriteLineAndConsole(GetName(remoteUserId) + ": " + message);
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

		private void SetupReflection()
		{
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
			Action<ulong, string, ChatEntryTypeEnum> chatMessageRecieved = ChatMessageRecieved;
			RegisterOnChatMessageAction(chatMessageRecieved);
		}

		private void RegisterOnChatMessageAction(Action<ulong, string, ChatEntryTypeEnum> action)
		{
			m_registerOnChatMessage.Call(Instance, new Object[] { action });
		}

		private void ChatMessageRecieved(ulong remoteUserId, string message, ChatEntryTypeEnum entryType)
		{
			if (OnChatMessage != null)
			{
				OnChatMessage(remoteUserId, message, entryType);
			}
		}

		private String GetName(ulong steamId)
		{
			if (DESERVE.Arguments.ModAPI)
			{
				List<IMyPlayer> players = new List<IMyPlayer>();
				MyAPIGateway.Players.GetPlayers(players);
				foreach (IMyPlayer player in players)
				{
					if (player.SteamUserId == steamId)
					{
						return player.DisplayName;
					}
				}
			}

			return steamId.ToString();
		}

		public void SendChatMessage(String message, ulong steamId = 0)
		{
			Object ChatMessage = SandboxGameWrapper.ChatMessageStruct.CreateStruct(message);

			if (!DESERVE.Arguments.ModAPI)
			{
				LogManager.ErrorLog.WriteLine(String.Format("DESERVE: SendChatMessage called, but ModAPIGateway not initialized. Stack Trace: {0}", (new StackTrace()).ToString()));
				return;
			}

			if (steamId == 0)
			{
				List<IMyPlayer> players = new List<IMyPlayer>();
				MyAPIGateway.Players.GetPlayers(players);
				if (players.Count > 0)
				{
					foreach (IMyPlayer player in players)
					{
						SendStruct(player.SteamUserId, ChatMessage);
					}
					if (OnChatMessage != null)
					{
						OnChatMessage(0, message, ChatEntryTypeEnum.ChatMsg);
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
