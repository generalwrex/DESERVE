using DESERVE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESERVE.Manager
{
	class ServerInstance : IServerInstance
	{

		#region Fields
		#endregion

		#region Events
		#endregion

		#region Properties
		public String Name { get; set; }
		public Boolean IsRunning { get; set; }
		//<TextBlock Foreground="{Binding RunningColor}" Grid.Column="2" Text="{Binding RunningString}"/>
		public String RunningString { get { return (IsRunning ? "Running" : "Stopped"); } }
		public String RunningColor { get { return (IsRunning ? "Green" : "Red"); } }
		#endregion

		#region Methods
		public ServerInstance(String name, Boolean isRunning)
		{
			Name = name;
			IsRunning = isRunning;
		}

		public void Start()
		{

		}

		public void Stop()
		{

		}

		public void Save()
		{

		}
		#endregion
	}
}
