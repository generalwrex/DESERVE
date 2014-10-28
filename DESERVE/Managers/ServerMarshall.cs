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

using DESERVE.Common;
using DESERVE.Common.Marshall;

using DESERVE.ErrorHandlers;

namespace DESERVE.Managers
{
	[WCFErrorBehaviorAttribute(typeof(WCFErrorHandler))]
	public class ServerMarshall : IServerMarshall
	{
		#region Fields
		#endregion

		#region Properties
		public String Name { get { return ServerInstance.Name; } }
		public Boolean IsRunning { get { return DedicatedServerWrapper.Program.IsRunning; } }
		public CommandLineArgs Arguments { get { return DESERVE.Arguments; } }
		#endregion

		#region Methods
		public ServerMarshall()
		{
		}

		#region "Events and Callbacks"

		public void RegisterEvents()
		{
			IServerMarshallCallbacks m_callbackChannel = OperationContext.Current.GetCallbackChannel<IServerMarshallCallbacks>();
			SandboxGameWrapper.NetworkManager.OnChatMessage += (ulong remoteUserId, String message, ChatEntryTypeEnum chatType) => { m_callbackChannel.OnChatMessage(remoteUserId, message); };
			SandboxGameWrapper.WorldManager.IsSavingChanged += m_callbackChannel.IsSavingChanged;
			DedicatedServerWrapper.Program.OnServerStarted += m_callbackChannel.OnServerStarted;
			DedicatedServerWrapper.Program.OnServerStopped += m_callbackChannel.OnServerStopped;
		}


		#region Logs And Console
		public void WriteToConsole(string message)
		{
			try
			{
				Console.WriteLine(message);	
			}
			catch (Exception)
			{	
				throw;
			}
			
		}

		public void WriteToErrorLog(string message)
		{	
			try
			{
				LogManager.ErrorLog.WriteLine(message);
			}
			catch (Exception)
			{	
				throw;
			}
		}

		public void WriteToErrorLogAndConsole(string message)
		{	
			try
			{
				LogManager.ErrorLog.WriteLineAndConsole(message);
			}
			catch (Exception)
			{	
				throw;
			}
		}
		#endregion

		#region Server Control
		public void Stop()
		{
			try
			{
				ServerInstance.Stop();
			}
			catch (Exception)
			{	
				throw;
			}
			
		}

		public void Save()
		{	
			try
			{
				ServerInstance.Save();
			}
			catch (Exception)
			{		
				throw;
			}
		}
		#endregion

		public void Heartbeat()
		{
			
		}

		#endregion
		#endregion
	}
}
