using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ServiceModel;

namespace DESERVE.Managers
{
	[ServiceContract]//(CallbackContract = typeof(IServerMarshallEvents))]
	public interface IServerMarshall
	{
		String Name { [OperationContract] get; }
		Boolean IsRunning { [OperationContract] get; }
		CommandLineArgs Arguments { [OperationContract] get; }

		[OperationContract]
		void Stop();

		[OperationContract]
		void Save();

		#region Chat

		//[OperationContract]
		//void ChatRecievedEvent();

		#endregion
	}
}
