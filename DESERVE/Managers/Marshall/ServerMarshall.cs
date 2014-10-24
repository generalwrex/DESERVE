using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamSDK;

using System.Runtime.Serialization;
using System.ServiceModel;
using DESERVE.ReflectionWrappers.DedicatedServerWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
namespace DESERVE.Managers
{

	class ServerMarshall : IServerMarshall
	{
		

		public ServerMarshall()
		{
			
		}

		#region "Server Control"
		public String Name { get { return ServerInstance.Name; } }
		public Boolean IsRunning { get { return DedicatedServerWrapper.Program.IsRunning; } }
		public CommandLineArgs Arguments { get { return DESERVE.Arguments; } }

		public void Stop()
		{
			ServerInstance.Stop();
			LogManager.MainLog.WriteLine("Admin stopped server");
		}

		public void Save()
		{
			ServerInstance.Save();
			LogManager.MainLog.WriteLine("Admin saved world");
		}
		#endregion

		#region Chat

		//static Action<ulong, string, ChatEntryTypeEnum> chatMessageRecieved = delegate { };

		//void ChatRecievedEvent()
		//{
		//	IServerMarshallEvents client = OperationContext.Current.GetCallbackChannel<IServerMarshallEvents>();
		//	chatMessageRecieved += client.OnChatRecieved;
		//}

		//chatMessageRecieved(remoteUserId, message, entryType) needs to be fired so the client can subscribe to the event
		


		#endregion


	}
}
