using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

using System.ServiceModel;
using System.ServiceModel.Web;
using System.Security;
using System.Security.Authentication;
using System.Security.Permissions;


namespace SEEDS
{
	[ServiceContract]
	interface IServerManager
	{
		[OperationContract]
		List<ServerInstance> GetServerInstances();

		[OperationContract]
		void StartServer(string saveFile);

		[OperationContract]
		void StopServer(ServerInstance server);

		[OperationContract]
		void StopAllServers();
	}
}
