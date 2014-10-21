using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SEEDS.ReflectionWrappers.SandboxGameWrappers
{
	class SandboxGameWrapper : ReflectionAssemblyWrapper
	{
		#region Fields
		private const string MainGameNamespace = "B337879D0C82A5F9C44D51D954769590";
		private static string ServerCoreNamespace = "168638249D29224100DB50BB468E7C07";

		private static MainGame m_mainGame;
		private static ServerCore m_serverCore;
		#endregion

		#region Properties
		public static MainGame MainGame { get { return m_mainGame; } }
		public static ServerCore ServerCore { get { return m_serverCore; } }
		#endregion

		#region Methods
		public SandboxGameWrapper()
			: base(Assembly.UnsafeLoadFrom("Sandbox.Game.dll"))
		{
			m_mainGame = new MainGame(MainGameNamespace);
			m_serverCore = new ServerCore(ServerCoreNamespace);
		}
		#endregion
	}
}
