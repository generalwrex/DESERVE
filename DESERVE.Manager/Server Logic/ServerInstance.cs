using DESERVE.Common;
using DESERVE.Manager.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DESERVE.Manager
{
	public class ServerInstance : IServerInstance
	{

		#region Fields
		private String m_name;
		private Boolean m_isRunning;
		private CommandLineArgs m_arguments;

		private ClientController m_clientController;
		#endregion

		#region Properties
		public String Name { get { return m_name; } }
		public Boolean IsRunning { get { return m_isRunning; } }
		//<TextBlock Foreground="{Binding RunningColor}" Grid.Column="2" Text="{Binding RunningString}"/>
		public String RunningString { get { return (IsRunning ? "Running" : "Stopped"); } }
		public String RunningColor { get { return (IsRunning ? "Green" : "Red"); } }
		public CommandLineArgs Arguments { get { return m_arguments; } }
		#endregion

		#region Methods
		public ServerInstance(String name)
		{
			m_name = name;
			m_clientController = new ClientController(m_name);
			m_isRunning = m_clientController.Connect();
		}

		public void Start()
		{
			ProcessStartInfo deserve = new ProcessStartInfo(Settings.Default.DESERVEPath, Arguments.ToString());
		}

		public void Stop()
		{
			m_clientController.StopServer();
		}

		public void Save(Boolean enhancedSave = false)
		{
			m_clientController.SaveServer();
		}
		#endregion
	}
}
