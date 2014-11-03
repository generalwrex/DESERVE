using DESERVE.Common;
using DESERVE.ReflectionWrappers.DedicatedServerWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Sandbox.ModAPI;
using System.Threading;


namespace DESERVE.Managers
{
	public class ServerInstance : ServerInfo
	{
		#region Fields
		private String m_saveFile;

		private List<ChatMessage> m_chatMessages;
		private List<Player> m_currentPlayers;
		private List<Player> m_joiningPlayers;

		private static Thread m_serverThread;
		private static ServerInstance m_serverInstance;

		private DedicatedServerWrapper m_dedicatedServerWrapper;
		private SandboxGameWrapper m_sandboxGameWrapper;

		private DateTime m_launchedTime;
		private DateTime m_lastSave;

		private Boolean m_isRunning;

		private static int _MS_PER_UPDATE_ = 5000;
		private System.Timers.Timer m_updateTimer;

		private static readonly object _lockObj = new object();

		#endregion

		#region Events
		public delegate void ServerRunningEvent();
		public event ServerRunningEvent OnServerStarted;
		public event ServerRunningEvent OnServerStopped;

		public delegate void PlayerActionEvent(Player player, PlayerAction action);
		public event PlayerActionEvent PlayerUpdated;

		public delegate void ChatMessageEvent(ChatMessage message);
		public event ChatMessageEvent OnChatMessage;
		#endregion
		
		#region Properties
		public static ServerInstance Instance { get { return m_serverInstance; } }
		public static Thread ServerThread { get { return m_serverThread; } }

		#region ServerInfo Properties
		public override String Name { get { return m_saveFile; } }
		public override Boolean IsRunning { get { return m_isRunning; } }
		public override List<Player> CurrentPlayers { get { return m_currentPlayers; } }
		public override TimeSpan Uptime { get { return DateTime.Now - m_launchedTime; } }
		public override DateTime LastSave { get { return m_lastSave; } }
		public override List<ChatMessage> ChatMessages { get { return m_chatMessages; } }
		#endregion
		#endregion

		#region Methods
		public ServerInstance()
		{
			m_chatMessages = new List<ChatMessage>();
			m_currentPlayers = new List<Player>();
			m_joiningPlayers = new List<Player>();
			m_launchedTime = DateTime.MinValue;
			m_saveFile = DESERVE.Arguments.Instance;
			m_serverThread = null;
			m_serverInstance = this;
			m_dedicatedServerWrapper = new DedicatedServerWrapper(Assembly.UnsafeLoadFrom("SpaceEngineersDedicated.exe"));
			m_sandboxGameWrapper = new SandboxGameWrapper(Assembly.UnsafeLoadFrom("Sandbox.Game.dll"));
			SandboxGameWrapper.NetworkManager.OnChatMessage += NetworkManager_OnChatMessage;
			SandboxGameWrapper.NetworkManager.OnPlayerConnected += NetworkManager_OnPlayerConnected;
			SandboxGameWrapper.NetworkManager.OnPlayerDisconnected += NetworkManager_OnPlayerDisconnected;

			m_updateTimer = new System.Timers.Timer(_MS_PER_UPDATE_);
			m_updateTimer.Elapsed += OnUpdateTimer;
			m_updateTimer.AutoReset = false;
			m_updateTimer.Start();
		}

		private void OnUpdateTimer(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (m_joiningPlayers.Count == 0)
			{
				m_updateTimer.Start();
				return;
			}
			List<Player> joiningPlayers;
			lock (_lockObj)
			{
				joiningPlayers = new List<Player>(m_joiningPlayers);
			}
			Player joiner;
			foreach (Player player in joiningPlayers)
			{
				joiner = player;
				List<IMyPlayer> currentPlayers = new List<IMyPlayer>();
				MyAPIGateway.Players.GetPlayers(currentPlayers);
				foreach (IMyPlayer currentPlayer in currentPlayers)
				{
					if (currentPlayer.SteamUserId == player.SteamId)
					{
						if (currentPlayer.Controller.ControlledEntity != null)
						{
							joiner.Name = currentPlayer.DisplayName;
							m_joiningPlayers.Remove(player);
							if (PlayerUpdated != null)
							{
								PlayerUpdated(joiner, PlayerAction.Entered);
							}
						}
					}
				}
			}
		}

		void NetworkManager_OnPlayerConnected(ulong steamId)
		{
			Player playerInfo = new Player();
			playerInfo.SteamId = steamId;

			m_currentPlayers.Add(playerInfo);
			if (PlayerUpdated != null)
			{
				PlayerUpdated(playerInfo, PlayerAction.Joined);
			}
			m_joiningPlayers.Add(playerInfo);
		}

		void NetworkManager_OnPlayerDisconnected(ulong steamId)
		{
			Player playerInfo = new Player();
			playerInfo.SteamId = steamId;

			m_currentPlayers.Remove(playerInfo);
			if (PlayerUpdated != null)
			{
				PlayerUpdated(playerInfo, PlayerAction.Left);
			}
		}

		void NetworkManager_OnChatMessage(ulong remoteUserId, string message, SteamSDK.ChatEntryTypeEnum entryType)
		{
			ChatMessage chatMessage = new ChatMessage();
			chatMessage.Message = message;
			chatMessage.Name = (remoteUserId == 0 ? "Server" : SandboxGameWrapper.NetworkManager.GetName(remoteUserId));
			chatMessage.SteamId = remoteUserId;
			chatMessage.Timestamp = DateTime.Now;
			ChatMessages.Add(chatMessage);

			if (OnChatMessage != null)
			{
				OnChatMessage(chatMessage);
			}

		}

		public void Start()
		{
			// Setup the arguments that DedicatedServer.exe will recieve.
			// DedicatedServer.exe -path "instance" -noconsole
			Object[] serverArgs = new Object[]
				{
					new String[] {
						"-path",
						DESERVE.InstanceDirectory,
						"-noconsole",
					}
				};

			// Setup the wait event to wait for server load.
			ManualResetEvent serverWaitEvent = new ManualResetEvent(false);

			// Registers serverWaitEvent.Set() to the MainGame.OnLoaded event.
			SandboxGameWrapper.MainGame.RegisterOnLoadedAction(
				() => serverWaitEvent.Set() //
				);

			// Prepare the thread that DedicatedServer.exe will run on.
			m_serverThread = DedicatedServerWrapper.Program.PrepareServerThread();

			LogManager.MainLog.WriteLineAndConsole("DESERVE: Loading server...");

			// Start DedicatedServer.exe This will call DedicatedServerWrapper.Program.ThreadStart [as setup in PrepareServerThread()]
			m_serverThread.Start(serverArgs);

			// Wait for the map to be loaded.
			serverWaitEvent.WaitOne();
			LogManager.MainLog.WriteLineAndConsole("DESERVE: Server Loaded.");

			// Initialize our wrappers now that the main game has been loaded.
			m_dedicatedServerWrapper.Init();
			m_sandboxGameWrapper.Init();

			// Register that we are now enabled.
			m_launchedTime = DateTime.Now;
			m_isRunning = true;

			// Fire the OnServerStarted event.
			if (OnServerStarted != null)
			{
				OnServerStarted();
			}
		}

		public void Stop()
		{
			SandboxGameWrapper.MainGame.SignalShutdown();
			if (m_serverThread.Join(60000))
			{
				LogManager.MainLog.WriteLineAndConsole("DESERVE: Server stopped successfully");
			}
			else
			{
				LogManager.MainLog.WriteLineAndConsole("DESERVE: Server shutdown timed out. Server aborted.");
				m_serverThread.Abort();
				ServerThreadStopped();
			}
		}

		internal void ServerThreadStopped()
		{
			m_isRunning = false;

			// Fire the OnServerStopped event.
			if (OnServerStopped != null)
			{
				OnServerStopped();
			}
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

		internal ServerInfo GetInfo()
		{
			return new ServerInfo(Name, IsRunning, CurrentPlayers, Uptime, LastSave, ChatMessages);
		}

		internal ServerInfoPartial GetInfoPartial()
		{
			return new ServerInfoPartial(IsRunning, Uptime, LastSave);
		}
		#endregion
	}
}
