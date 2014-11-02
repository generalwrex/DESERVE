using DESERVE.Common;
using DESERVE.Manager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;

namespace DESERVE.Manager
{
	public class ServerInstance : INotifyPropertyChanged
	{

		#region Fields
		private String m_name;
		private Boolean m_isRunning;
		private CommandLineArgs m_arguments;
		private String m_instanceDir;

		private ObservableCollection<Player> m_currentPlayers;
		private TimeSpan m_uptime;
		private DateTime m_lastSave;
		private String m_bindingIp;
		private String m_serverName;
		private ObservableCollection<ChatMessage> m_chatMessages;

		private ClientController m_clientController;

		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#endregion

		#region Properties
		public String Name { get { return m_name; } }
		

		public Boolean IsRunning { get { return m_isRunning; } }
		public Boolean NotIsRunning { get { return !IsRunning; } }
		//<TextBlock Foreground="{Binding RunningColor}" Grid.Column="2" Text="{Binding RunningString}"/>
		public String RunningString { get { return (IsRunning ? "Running" : "Stopped"); } }
		public String RunningColor { get { return (IsRunning ? "Green" : "Red"); } }

		public CommandLineArgs Arguments { get { return m_arguments; } set { m_arguments = value; } }
		public String InstanceDirectory { get { return m_instanceDir; } set { m_instanceDir = value; } }

		public String BindingIp { get { return m_bindingIp; } }
		public String ServerName { get { return m_serverName; } }
		public ObservableCollection<Player> CurrentPlayers { get { return m_currentPlayers; } }
		public Int32 PlayerCount { get { return CurrentPlayers.Count; } }
		public String Uptime { get { return m_uptime.ToString(@"dd\:hh\:mm\:ss"); } }
		public String LastSave { get { return m_lastSave.ToString("HH:mm:ss dd/mmm/yyyy"); } }
		public ObservableCollection<ChatMessage> ChatMessages { get { return m_chatMessages; } }


		#endregion

		#region Methods
		public ServerInstance(String instanceDir, String name)
		{
			m_chatMessages = new ObservableCollection<ChatMessage>();
			m_instanceDir = instanceDir;
			m_arguments = FileManager.Instance.LoadArguments(instanceDir, name, this);
			m_name = name;
			m_clientController = new ClientController(m_name, this);
			m_isRunning = false;
			m_bindingIp = "";
			m_serverName = "";
		}

		public void Start()
		{
			if (String.IsNullOrEmpty(Settings.Default.DESERVEPath))
			{
				MessageBox.Show("Make sure to set the path to DESERVE.EXE in the \"Options\" menu.", 
					"DESERVE.EXE not found!",MessageBoxButton.OK, MessageBoxImage.Error,MessageBoxResult.OK);
				return;
			}

			ProcessStartInfo deserve = new ProcessStartInfo(Path.Combine(Settings.Default.DESERVEPath, "DESERVE.exe"), Arguments.ToString());
			deserve.WorkingDirectory = Settings.Default.DESERVEPath;
			try
			{
				Process.Start(deserve);
			}
			catch (OperationCanceledException)
			{
				// Don't do anything if they canceled the UAC prompt
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Make sure to set the path to DESERVE.EXE in the \"Options\" menu.",
					"DESERVE.EXE not found!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
			}
		}

		public void Stop()
		{
			m_clientController.StopServer();
		}

		public void Save(Boolean enhancedSave = false)
		{
			m_clientController.SaveServer();
		}

		internal void Update(ServerInfo serverInfo)
		{
			m_isRunning = serverInfo.IsRunning;
			m_currentPlayers = new ObservableCollection<Player>(serverInfo.CurrentPlayers);
			m_uptime = serverInfo.Uptime;
			m_lastSave = serverInfo.LastSave;
			m_chatMessages = new ObservableCollection<ChatMessage>(serverInfo.ChatMessages);
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(null));
			}
		}
		internal void Update(ServerInfoPartial serverInfo)
		{
			m_isRunning = serverInfo.IsRunning;
			m_uptime = serverInfo.Uptime;
			m_lastSave = serverInfo.LastSave;
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs("IsRunning"));
				PropertyChanged(this, new PropertyChangedEventArgs("NotIsRunning"));
				PropertyChanged(this, new PropertyChangedEventArgs("RunningString"));
				PropertyChanged(this, new PropertyChangedEventArgs("RunningColor"));
				PropertyChanged(this, new PropertyChangedEventArgs("Uptime"));
				PropertyChanged(this, new PropertyChangedEventArgs("LastSave"));
			}
		}

		public void SendChatMessage(String message)
		{
			ChatMessage chatMessage = new ChatMessage();
			chatMessage.Message = message;
			chatMessage.Timestamp = DateTime.Now;
			chatMessage.SteamId = 0;
			chatMessage.Name = "Server";

			m_clientController.SendChatMessage(chatMessage);

		}
		#endregion
	}
}
