using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ServiceModel;

namespace DESERVE.Managers
{
	
	class ServerMarshall : IServerMarshall
	{

		public ServerMarshall()
		{

		}

		public String Name { get { return ServerInstance.Name; } }
		public Boolean IsRunning { get { return ServerInstance.IsRunning; } }


		public void Start(CommandLineArgs args)
		{
			ServerInstance.Start(args);
			LogManager.MainLog.WriteLine("Admin started server");
		}

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


	}
}
