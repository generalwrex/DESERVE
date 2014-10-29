using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESERVE.Manager
{
	class ServerInstance
	{

		#region Fields
		#endregion

		#region Events
		#endregion

		#region Properties
		public String Name { get; set; }
		public Boolean IsRunning { get; set; }
		public String RunningString { get { return (IsRunning ? "Running" : "Stopped"); } }
		#endregion

		#region Methods
		public ServerInstance(String name, Boolean isRunning)
		{
			Name = name;
			IsRunning = isRunning;
		}
		#endregion
	}
}
