using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	class SandboxGameWrapper : ReflectionAssemblyWrapper
	{
		#region Fields
		private const String MainGameNamespace = "B337879D0C82A5F9C44D51D954769590";
		private const String ServerCoreNamespace = "168638249D29224100DB50BB468E7C07";
		private const String WorldManagerNamespace = "AAC05F537A6F0F6775339593FBDFC564";
		private const String MPSessionNamespace = "91D02AC963BE35D1F9C1B9FBCFE1722D";
		private const String NetworkManagerNamespace = "C42525D7DE28CE4CFB44651F3D03A50D";

		private static MainGame m_mainGame;
		private static WorldManager m_worldManager;
		private static MPSession m_mpSession;
		private static NetworkManager m_networkManager;
		private static SteamNetworkWrapper m_steamNetworkWrapper;
		private static WorldResourceManager m_worldResourceManager;
		#endregion

		#region Properties
		public static MainGame MainGame { get { return m_mainGame; } }
		public static WorldManager WorldManager { get { return m_worldManager; } }
		public static MPSession MPSession { get { return m_mpSession; } }
		public static NetworkManager NetworkManager { get { return m_networkManager; } }
		public static SteamNetworkWrapper SteamNetworkWrapper { get { return m_steamNetworkWrapper; } }
		public static WorldResourceManager WorldResourceManager { get { return m_worldResourceManager; } }
		#endregion

		#region Methods
		public SandboxGameWrapper(Assembly Assembly)
			: base(Assembly)
		{
			m_mainGame = new MainGame(Assembly, MainGameNamespace);
			m_worldManager = new WorldManager(Assembly, WorldManagerNamespace);
			m_mpSession = new MPSession(Assembly, MPSessionNamespace);
			m_networkManager = new NetworkManager(Assembly, NetworkManagerNamespace);
			m_steamNetworkWrapper = new SteamNetworkWrapper(Assembly, NetworkManagerNamespace);
			m_worldResourceManager = new WorldResourceManager(Assembly, WorldManagerNamespace);
		}

		internal void Init()
		{
			m_mainGame.Init();
			m_worldManager.Init();
			m_mpSession.Init();
			m_networkManager.Init();
			m_steamNetworkWrapper.Init();
			m_worldResourceManager.Init();
		}
		#endregion
	}
}
