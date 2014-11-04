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

		private WCFClient m_wcfClient;

		private System.Windows.Threading.Dispatcher m_dispatcher;

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

		
		public String InstanceDirectory { get { return m_instanceDir; } set { m_instanceDir = value; } }

		public String BindingIp { get { return m_bindingIp; } }
		public String ServerName { get { return m_serverName; } }
		public ObservableCollection<Player> CurrentPlayers { get { return m_currentPlayers; } }
		public Int32 PlayerCount { get { return CurrentPlayers.Count; } }
		public String Uptime { get { return m_uptime.ToString(@"dd\:hh\:mm\:ss"); } }
		public String LastSave { get { return m_lastSave.ToString("HH:mm:ss dd/MMM/yyyy"); } }
		public ObservableCollection<ChatMessage> ChatMessages { get { return m_chatMessages; } }
		public DedicatedConfig DedicatedConfiguration { get; set; }

		#region Server Settings
		public CommandLineArgs Arguments { get { return m_arguments; } set { m_arguments = value; } }
		//BUG:  For some reason the textboxes are clearing out after 5 seconds..
		public String Server_BindIP { get { return DedicatedConfiguration.IP; } set { DedicatedConfiguration.IP = value; } }
		public Int32 Server_BindPort { get { return DedicatedConfiguration.ServerPort; } set { DedicatedConfiguration.ServerPort = value; } }
		public String Server_WorldName { get { return DedicatedConfiguration.WorldName; } set { DedicatedConfiguration.IP = value; } }
		public String Server_Name { get { return DedicatedConfiguration.ServerName; } set { DedicatedConfiguration.ServerName = value;} } // Todo Hook to ModAPI for realtime
		public String Server_Pass { get; set; } // Todo Hook to ModAPI for realtime
		public ulong Server_GroupID { get { return DedicatedConfiguration.GroupID; } set { DedicatedConfiguration.GroupID = value; } }
		#endregion
		#endregion

		#region Methods
		public ServerInstance(String instanceDir, String name, System.Windows.Threading.Dispatcher dispatcher)
		{
			this.DedicatedConfiguration = DedicatedConfig.LoadDedicatedConfig(instanceDir, name);
			m_chatMessages = new ObservableCollection<ChatMessage>();
			m_instanceDir = instanceDir;
			m_arguments = FileManager.Instance.LoadArguments(instanceDir, name, this);
			m_name = name;
			m_wcfClient = new WCFClient(this);
			m_isRunning = false;
			m_bindingIp = "";
			m_serverName = "";
			m_dispatcher = dispatcher;
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
			m_wcfClient.StopServer();
		}

		public void Save(Boolean enhancedSave = false)
		{
			m_wcfClient.SaveServer();
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

			m_wcfClient.SendChatMessage(chatMessage);

		}
		#endregion

		internal void PlayerUpdate(Player player, PlayerAction action)
		{
			RunInUiThread(() =>
			{
				if (action == PlayerAction.Joined)
				{
					CurrentPlayers.Add(player);
				}
				else if (action == PlayerAction.Left)
				{
					CurrentPlayers.Remove(player);
				}
				else
				{
					int i = CurrentPlayers.IndexOf(player);
					CurrentPlayers[i] = player;
				}
				PropertyChanged(this, new PropertyChangedEventArgs("CurrentPlayers"));
			});
		}

		internal void ChatUpdate(ChatMessage message)
		{
			RunInUiThread(() => m_chatMessages.Add(message));
		}

		private void RunInUiThread(Action action)
		{
			m_dispatcher.BeginInvoke(action);
		}
	}
}
