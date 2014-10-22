using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ServiceModel;

namespace DESERVE.Managers
{
	[ServiceContract]
	interface IServerMarshall
	{

		String Name { get; }
		Boolean IsRunning { get; }

		[OperationContract]
		void Start(CommandLineArgs args);

		[OperationContract]
		void Stop();

		[OperationContract]
		void Save();
	}
}
