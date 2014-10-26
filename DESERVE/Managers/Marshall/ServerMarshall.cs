using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamSDK;
using System.Reflection;

using System.Runtime.Serialization;
using System.ServiceModel;
using DESERVE.ReflectionWrappers.DedicatedServerWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
namespace DESERVE.Managers
{
	public class ServerMarshall : IServerMarshall
	{
		#region Constructor
		public ServerMarshall()
		{
			RegisterEvents();	
		}
		#endregion

		#region "Server Control"
		public String Name { get { return ServerInstance.Name; } }
		public Boolean IsRunning { get { return DedicatedServerWrapper.Program.IsRunning; } }
		public CommandLineArgs Arguments { get { return DESERVE.Arguments; } }

		public void Stop()
		{
			ServerInstance.Stop();
		}

		public void Save()
		{
			ServerInstance.Save();
		}
		#endregion

		#region "Logs And Console"

		public void WriteToConsole(string message)
		{
			Console.WriteLine(message);
		}

		#endregion

		#region "Events and Callbacks"

		private void RegisterEvents()
		{
			SandboxGameWrapper.NetworkManager.OnChatMessage += NetworkManager_OnChatMessage;
			SandboxGameWrapper.WorldManager.IsSavingChanged += WorldManager_IsSavingChanged;
			DedicatedServerWrapper.Program.OnServerStarted += Program_OnServerStarted;
			DedicatedServerWrapper.Program.OnServerStopped += Program_OnServerStopped;
		}

		private static Action<ulong, string> m_chatCallback = delegate { };
		private static Action<bool> m_savingChangedCallback = delegate { };
		private static Action m_onServerStartedCallback = delegate { };
		private static Action m_onServerStoppedCallback = delegate { };

		private void NetworkManager_OnChatMessage(ulong remoteUserId, string message, ChatEntryTypeEnum entryType) { m_chatCallback(remoteUserId, message); }
		private void WorldManager_IsSavingChanged(bool isSaving) { m_savingChangedCallback(isSaving); }
		private void Program_OnServerStopped() { m_onServerStoppedCallback(); }
		private void Program_OnServerStarted() { m_onServerStartedCallback(); }

		public void SubscribeToCallbacks()
		{
			IServerMarshallCallbacks callback = OperationContext.Current.GetCallbackChannel<IServerMarshallCallbacks>();

			m_chatCallback += callback.OnChatMessage;
			m_savingChangedCallback += callback.IsSavingChanged;
			m_onServerStartedCallback += callback.OnServerStarted;
			m_onServerStoppedCallback += callback.OnServerStopped;
		}
		#endregion
	}
}
