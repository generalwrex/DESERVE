using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ServiceModel;
using System.Reflection;

namespace DESERVE.Common.Marshall
{
	[ServiceContract(CallbackContract = typeof(IServerMarshallCallbacks))]
	public interface IServerMarshall
	{
		// Allows the client to subscribe to events
		[OperationContract(IsOneWay = true)]
		void RegisterEvents();

		#region "Server Control"
		String Name { [OperationContract] get; }
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
		void WriteToErrorLog(string message);

		[OperationContract]
		void WriteToErrorLogAndConsole(string message);
		#endregion

		#region Chat
		#endregion

		#region General
		[OperationContract]
		void Heartbeat();
		#endregion
	}
}
