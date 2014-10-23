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

		private const string RegisterOnChatMessageMethod = "8A73057A206BFCA00EC372183441891A";
		private const string InstanceField = "8E8199A1194065205F01051DC8B72DE7";
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
		}

		public override void Init()
		{
			Action<ulong, string, ChatEntryTypeEnum> chatMessageRecieved = ChatMessageRecieved;
			RegisterOnChatMessageAction(chatMessageRecieved);
		}

		private void RegisterOnChatMessageAction(Action<ulong, string, ChatEntryTypeEnum> action)
		{
			CallObjectMethod(Instance, RegisterOnChatMessageMethod, new Object[] { action });
		}

		private void ChatMessageRecieved(ulong remoteUserId, string message, ChatEntryTypeEnum entryType)
		{
			LogManager.ChatLog.WriteLineAndConsole(GetName(remoteUserId) + ": " + message);
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
