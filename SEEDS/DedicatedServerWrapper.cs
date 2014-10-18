using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SEEDS
{
	class DedicatedServerWrapper
	{
		private static Assembly m_dedicatedServerAssembly;
		private static Assembly m_sandboxGameAssembly;

		private const string DedicatedServerNamespace = "83BCBFA49B3A2A6EC1BC99583DA2D399";
		private const string DedicatedServerClass = "49BCFF86BA276A9C7C0D269C2924DE2D";
		private const string DedicatedServerMainMethod = "26A7ABEA729FAE1F24679E21470F8E98";

		private const string MainGameNamespace = "B337879D0C82A5F9C44D51D954769590";
		private const string MainGameClass = "B3531963E948FB4FA1D057C4340C61B4";
		private const string MainGameInstance = "392503BDB6F8C1E34A232489E2A0C6D4";
		private const string MainGameSignalShutdownMethod = "DA95E633B86E22CF269880CE57124695";

		public static MethodInfo DedicatedServerStartupMethod { get { return m_dedicatedServerAssembly.GetType(DedicatedServerNamespace + "." + DedicatedServerClass).GetMethod(DedicatedServerMainMethod, BindingFlags.Static | BindingFlags.NonPublic); } }
		public static MethodInfo DedicatedServerShutdownMethod { get { return m_sandboxGameAssembly.GetType(MainGameNamespace + "." + MainGameClass + "." + MainGameInstance).GetMethod(MainGameSignalShutdownMethod, BindingFlags.Static | BindingFlags.Public); } }
	
		public DedicatedServerWrapper()
		{
			if (m_dedicatedServerAssembly == null)
			{
				m_dedicatedServerAssembly = Assembly.UnsafeLoadFrom("SpaceEngineersDedicated.exe");
			}

			if (m_sandboxGameAssembly == null)
			{
				m_sandboxGameAssembly = Assembly.UnsafeLoadFrom("Sandbox.Game.dll");
			}
		}
	}
}
