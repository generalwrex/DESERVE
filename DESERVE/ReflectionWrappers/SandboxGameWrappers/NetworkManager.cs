using DESERVE.Managers;
using SteamSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	class NetworkManager : ReflectionClassWrapper
	{
		#region Fields
		private const string Class = "9CDBE03D49929CA686F49B66EE307DD7";

		private ReflectionMethod m_registerOnChatMessage;
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
			LogManager.ChatLog.WriteLineAndConsole( + ": " + message);
			if (OnChatMessage != null)
			{
				OnChatMessage(remoteUserId, message, entryType);
			}
		}

		private String GetName(ulong steamId)
		{
			return steamId.ToString();
		}
		#endregion
	}
}
