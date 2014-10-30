using DESERVE.Common;
using DESERVE.ReflectionWrappers.DedicatedServerWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Sandbox.ModAPI;


namespace DESERVE.Managers
{
	public class ServerInstance
	{
		#region Fields
		private String m_saveFile;

		private ObservableCollection<ChatMessage> m_chatMessages;

		private static Thread m_serverThread;
		private static ServerInstance m_serverInstance;

		private DedicatedServerWrapper m_dedicatedServerWrapper;
		private SandboxGameWrapper m_sandboxGameWrapper;

		private DateTime m_launchedTime;
		private DateTime m_lastSave;

		#endregion

		#region Events
		public event ServerStateEvent ServerStarted;
		public event ServerStateEvent ServerStopped;
		#endregion

		#region Properties
		public static ServerInstance Instance { get { return m_serverInstance; } }
		public static Thread ServerThread { get { return m_serverThread; } }

		public String Name { get { return m_saveFile; } }
		public Boolean IsRunning { get; set; }
		public ObservableCollection<Player> CurrentPlayers { get { return GetCurrentPlayers(); } }
		public TimeSpan Uptime { get { return DateTime.Now - m_launchedTime; } }
		public DateTime LastSave { get { return m_lastSave; } }
		public ObservableCollection<ChatMessage> ChatMessages { get { return m_chatMessages; } }
		#endregion

		#region Methods
		public ServerInstance(CommandLineArgs args)
		{
			m_chatMessages = new ObservableCollection<ChatMessage>();
			m_launchedTime = DateTime.MinValue;
			m_saveFile = args.Instance;
			m_serverThread = null;
			m_serverInstance = this;
			m_dedicatedServerWrapper = new DedicatedServerWrapper(Assembly.UnsafeLoadFrom("SpaceEngineersDedicated.exe"));
			m_sandboxGameWrapper = new SandboxGameWrapper(Assembly.UnsafeLoadFrom("Sandbox.Game.dll"));
			DedicatedServerWrapper.Program.OnServerStarted += Program_OnServerStarted;
			DedicatedServerWrapper.Program.OnServerStopped += Program_OnServerStopped;
			SandboxGameWrapper.NetworkManager.OnChatMessage += NetworkManager_OnChatMessage;
		}

		void NetworkManager_OnChatMessage(ulong remoteUserId, string message, SteamSDK.ChatEntryTypeEnum entryType)
		{
			ChatMessage chatMessage = new ChatMessage();
			chatMessage.Message = message;
			chatMessage.Name = (remoteUserId == 0 ? "Server" : SandboxGameWrapper.NetworkManager.GetName(remoteUserId));
			chatMessage.SteamId = remoteUserId;
			chatMessage.Timestamp = DateTime.Now;
			ChatMessages.Add(chatMessage);
		}

		void Program_OnServerStarted()
		{
			m_launchedTime = DateTime.Now;
			IsRunning = true;
		}

		void Program_OnServerStopped()
		{
			IsRunning = false;
		}

		public void Start()
		{
			Object[] serverArgs = new Object[]
				{
					new String[] {
						"-path",
						DESERVE.InstanceDirectory,
						"-noconsole",
					}
				};

			m_serverThread = DedicatedServerWrapper.Program.StartServer(serverArgs);

			m_dedicatedServerWrapper.Init();
			m_sandboxGameWrapper.Init();
		}

		public void Stop()
		{
			SandboxGameWrapper.MainGame.SignalShutdown();
			m_serverThread.Join(60000);
			m_serverThread.Abort();
		}

		public void Save()
		{
			bool enhancedSave = true;
			m_lastSave = DateTime.Now;
			if (enhancedSave)
			{
				SandboxGameWrapper.WorldManager.EnhancedSave();
			}
			else
			{
				SandboxGameWrapper.WorldManager.Save();
			}
		}

		public void SendChatMessage(ChatMessage message)
		{
			SandboxGameWrapper.NetworkManager.SendChatMessage(message.Message, message.SteamId);
		}

		public ObservableCollection<Player> GetCurrentPlayers()
		{
			List<IMyPlayer> players = new List<IMyPlayer>();
			ObservableCollection<Player> currentPlayers = new ObservableCollection<Player>();
			MyAPIGateway.Players.GetPlayers(players);
			if (players.Count > 0)
			{
				foreach (IMyPlayer player in players)
				{
					currentPlayers.Add(new Player() { Name = player.DisplayName, SteamId = player.SteamUserId });
				}
			}
			return currentPlayers;
		}
		#endregion
	}
}
