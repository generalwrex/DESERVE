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
		#region Fields
		private IServerMarshallCallbacks m_callbackChannel;
		#endregion

		#region Properties
		public String Name { get { return ServerInstance.Name; } }
		public Boolean IsRunning { get { return DedicatedServerWrapper.Program.IsRunning; } }
		public CommandLineArgs Arguments { get { return DESERVE.Arguments; } }
		#endregion

		#region Methods
		public ServerMarshall()
		{
			m_callbackChannel = OperationContext.Current.GetCallbackChannel<IServerMarshallCallbacks>();
		}

		#region "Events and Callbacks"

		public void RegisterEvents()
		{
			SandboxGameWrapper.NetworkManager.OnChatMessage += (ulong remoteUserId, String message, ChatEntryTypeEnum chatType) => { m_callbackChannel.OnChatMessage(remoteUserId, message, chatType); };
			SandboxGameWrapper.WorldManager.IsSavingChanged += m_callbackChannel.IsSavingChanged;
			DedicatedServerWrapper.Program.OnServerStarted += m_callbackChannel.OnServerStarted;
			DedicatedServerWrapper.Program.OnServerStopped += m_callbackChannel.OnServerStopped;
		}


		#region Logs And Console
		public void WriteToConsole(string message)
		{
			Console.WriteLine(message);
		}
		#endregion

		#region Server Control
		public void Stop()
		{
			ServerInstance.Stop();
		}

		public void Save()
		{
			ServerInstance.Save();
		}
		#endregion

		#endregion
		#endregion
	}
}
