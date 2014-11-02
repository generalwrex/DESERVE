using DESERVE.Common;
using DESERVE.Managers;
using DESERVE.ReflectionWrappers.DedicatedServerWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using System;
using System.IO;
using System.Reflection;
using System.Timers;

namespace DESERVE //DEdicated SERVer, Enhanced
{
	class DESERVE
	{
		#region Fields
		private static String _SE_INSTANCE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "SpaceEngineersDedicated");

		private CommandLineArgs m_commandLineArgs;
		private LogManager m_logManager;
		private ServerInstance m_serverInstance;
		private PluginManager m_pluginManager;
		private WCFService m_wcfService;

		private static DESERVE m_instance;
		#endregion

		#region Properties
		public static Version Version { get { return Assembly.GetEntryAssembly().GetName().Version; } }
		public static String BuildBranch { get { return "Dev Branch"; } }
		public static String VersionString { get { return Version.ToString(3) + " " + BuildBranch; } }
		public static DESERVE Instance { get { return m_instance; } }
		public static String InstanceDirectory { get { return Path.Combine(_SE_INSTANCE_PATH, DESERVE.Arguments.Instance); } }
		public static CommandLineArgs Arguments { get { return Instance.m_commandLineArgs; } }
		#endregion

		#region Methods
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// <param name="args"></param>
		static void Main(String[] args)
		{
			Console.Title = "DESERVE v" + DESERVE.VersionString;
			DESERVE program = new DESERVE(args);

			program.Run();

			LogManager.MainLog.WriteLineAndConsole("DESERVE Quit.");
		}

		public DESERVE(string[] args)
		{
			m_instance = this;
			m_commandLineArgs = new CommandLineArgs(args);
			m_logManager = new LogManager(DESERVE.Arguments.LogDirectory);
			m_serverInstance = new ServerInstance();

			LogManager.MainLog.WriteLineAndConsole(String.Format("DESERVE v{0}", VersionString));
			LogManager.MainLog.WriteLineAndConsole(String.Format("DESERVE Arguments: {0}", DESERVE.Arguments.ToString()));

			if (DESERVE.Arguments.Plugins)
			{
				// Initialize the Plugin Manager.
				m_pluginManager = new PluginManager();
			}

			if (DESERVE.Arguments.WCF)
			{
				// Initialize the WCF NamedPipe.
				m_wcfService = new WCFService();
			}
		}

		private void Run()
		{
			// Start the dedicated server.
			ServerInstance.Instance.Start();

			// Setup autosave timer.
			if (DESERVE.Arguments.AutosaveMinutes > 0)
			{
				System.Timers.Timer autoSave = new System.Timers.Timer(DESERVE.Arguments.AutosaveMinutes * 60000);
				autoSave.AutoReset = true;
				autoSave.Elapsed += AutoSave;
				autoSave.Start();
			}

			Console.WriteLine();
			Console.WriteLine("DESERVE: Press Escape to shut down server. F1 for more commands.");
			while (ServerInstance.Instance.IsRunning)
			{
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey(true);
					switch (key.Key)
					{
						case ConsoleKey.Escape:
							ServerInstance.Instance.Stop();
							break;
						case ConsoleKey.F1:
							Console.WriteLine("DESERVE: Commands");
							Console.WriteLine("    F1 - This help dialog.");
							Console.WriteLine("    HOME - Save world.");
							Console.WriteLine("    ESCAPE - Save and Shutdown.");
							break;
						case ConsoleKey.Home:
							Console.WriteLine("DESERVE: Saving World.");
							ServerInstance.Instance.Save();
							break;
						default:
							break;
					}
				}
			}
		}

		private void AutoSave(object sender, ElapsedEventArgs e)
		{
			if (ServerInstance.Instance.IsRunning)
			{
				ServerInstance.Instance.Save();
			}
		}
		#endregion
	}
}
