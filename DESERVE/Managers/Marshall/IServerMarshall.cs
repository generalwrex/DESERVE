using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ServiceModel;
using System.Reflection;

namespace DESERVE.Managers
{
	[ServiceContract(CallbackContract = typeof(IServerMarshallCallbacks))]
	public interface IServerMarshall
	{
		#region "Server Control"
		String Name { [OperationContract] get; }
		Boolean IsRunning { [OperationContract] get; }
		CommandLineArgs Arguments { [OperationContract] get; }

		[OperationContract]
		void Stop();

		[OperationContract]
		void Save();
		#endregion

		#region "Logs And Console"
		[OperationContract]
		void WriteToConsole(string message);

		[OperationContract]
		void WriteToLog(LogType logType, WriteTo writeTo, String message);
		#endregion

		#region Chat

		[OperationContract(IsOneWay = true)]
		void SubscribeTo_OnChatReceived();

		#endregion
	}
}
