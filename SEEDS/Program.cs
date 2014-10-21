using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DESERVE
{
	class DESERVE
	{
		#region Fields
		private CommandLineArgs m_commandLineArgs;
		private LogManager m_logManager;
		#endregion

		#region Properties
		static public Version Version { get { return Assembly.GetEntryAssembly().GetName().Version; } }
		static public String BuildBranch { get { return "Dev"; } }
		static public String VersionString { get { return Version.ToString(3) + " " + BuildBranch; } }
		#endregion

		#region Methods
		static void Main(string[] args)
		{
			DESERVE program = new DESERVE(args);

			ServerInstance.Start("Test");

			while (ServerInstance.IsRunning)
			{
				Thread.Sleep(200);
			}
		}

		public DESERVE(string[] args)
		{
			m_commandLineArgs = new CommandLineArgs(args);
			m_logManager = new LogManager(m_commandLineArgs.LogDirectory);

			LogManager.MainLog.WriteLineAndConsole("DESERVE " + VersionString);
		}
		#endregion
	}
}
