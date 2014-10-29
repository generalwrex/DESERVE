using DESERVE.Common;
using DESERVE.Manager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DESERVE.Manager
{
	public class ServerInstance : ServerInfo, INotifyPropertyChanged
	{

		#region Fields
		private String m_name;
		private Boolean m_isRunning;
		private CommandLineArgs m_arguments;
		private String m_instanceDir;

		private Int32 m_currentPlayers;
		private TimeSpan m_uptime;
		private DateTime m_lastSave;

		private ClientController m_clientController;

		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#endregion

		#region Properties
		public String Name { get { return m_name; } }

		public Boolean IsRunning { get { return m_isRunning; } }
		//<TextBlock Foreground="{Binding RunningColor}" Grid.Column="2" Text="{Binding RunningString}"/>
		public String RunningString { get { return (IsRunning ? "Running" : "Stopped"); } }
		public String RunningColor { get { return (IsRunning ? "Green" : "Red"); } }

		public CommandLineArgs Arguments { get { return m_arguments; } set { m_arguments = value; } }
		public String InstanceDirectory { get { return m_instanceDir; } set { m_instanceDir = value; } }

		public Int32 CurrentPlayers { get { return m_currentPlayers; } }
		public TimeSpan Uptime { get { return m_uptime; } }
		public DateTime LastSave { get { return m_lastSave; } }


		#endregion

		#region Methods
		public ServerInstance(String instanceDir, String name)
		{
			m_instanceDir = instanceDir;
			m_arguments = FileManager.Instance.LoadArguments(instanceDir, name, this);
			m_name = name;
			m_clientController = new ClientController(m_name, this);
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

		public void Update(ServerInfo serverInfo)
		{
			m_isRunning = serverInfo.IsRunning;
			m_currentPlayers = serverInfo.CurrentPlayers;
			m_uptime = serverInfo.Uptime;
			m_lastSave = serverInfo.LastSave;
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(null));
			}
		}
		#endregion
	}
}
