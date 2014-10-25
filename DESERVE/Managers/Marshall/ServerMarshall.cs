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
	[DataContract]
	public enum LogType
	{
		[EnumMember]
		ErrorLog,
		[EnumMember]
		MainLog
	}
	[DataContract]
	public enum WriteTo
	{
		[EnumMember]
		Line,
		[EnumMember]
		LineAndConsole
	}

	[DataContract]
	public class ServerMarshall : IServerMarshall
	{

		public ServerMarshall()
		{
			RegisterEvents();	
		}


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

		public void WriteToLog(LogType logType, WriteTo writeTo, String message)
		{
			switch (logType)
			{
				case LogType.ErrorLog:
					switch (writeTo)
					{
						case WriteTo.Line:
							LogManager.ErrorLog.WriteLine(message);
							break;
						case WriteTo.LineAndConsole:
							LogManager.ErrorLog.WriteLineAndConsole(message);
							break;
					}			
					break;
				case LogType.MainLog:
					switch (writeTo)
					{
						case WriteTo.Line:
							LogManager.MainLog.WriteLine(message);
							break;
						case WriteTo.LineAndConsole:
							LogManager.MainLog.WriteLineAndConsole(message);
							break;
					}			
					break;
			}
		}
		#endregion

		#region Chat

		static Action<ulong, string> chatCallback = delegate {};

		public void SubscribeTo_OnChatReceived()
		{
			IServerMarshallCallbacks callback = OperationContext.Current.GetCallbackChannel<IServerMarshallCallbacks>();
			chatCallback += callback.ChatMessageReceived;
		}

		void NetworkManager_OnChatMessage(ulong remoteUserId, string message, ChatEntryTypeEnum entryType)
		{
			chatCallback(remoteUserId, message);
		}

		#endregion


		#region "Registers"

		public void RegisterEvents()
		{
			SandboxGameWrapper.NetworkManager.OnChatMessage += NetworkManager_OnChatMessage;
		}

		#endregion
	}
}
