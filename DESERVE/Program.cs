using DESERVE.Managers;
using DESERVE.ReflectionWrappers.DedicatedServerWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.ServiceModel;
using System.IO;
using DESERVE.Common;

namespace DESERVE //DEdicated SERVer, Enhanced
{
	class DESERVE
	{
		#region Fields
		private static String _SE_INSTANCE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "SpaceEngineersDedicated");
		private static Int32 _PLUGIN_UPDATE_FREQUENCY = 200; //Measured in ms;

		private CommandLineArgs m_commandLineArgs;
		private LogManager m_logManager;
		private PluginManager m_pluginManager;

		private ServiceHost m_pipedService;
		private static DESERVE m_instance;
		#endregion

		#region Properties
		public static Version Version { get { return Assembly.GetEntryAssembly().GetName().Version; } }
		public static String BuildBranch { get { return "DevBuild"; } }
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
			DESERVE program = new DESERVE(args);

			program.Run();

			LogManager.MainLog.WriteLineAndConsole("DESERVE Quit.");
		}

		public DESERVE(string[] args)
		{
			m_instance = this;
			m_commandLineArgs = new CommandLineArgs(args);
			m_logManager = new LogManager(DESERVE.Arguments.LogDirectory);

			LogManager.MainLog.WriteLineAndConsole("DESERVE Initialized. Version " + VersionString);

			LogManager.MainLog.WriteLineAndConsole("DESERVE Arguments: " + DESERVE.Arguments.ToString());

			if (DESERVE.Arguments.Plugins)
			{
				m_pluginManager = new PluginManager();
			}

			if (DESERVE.Arguments.WCF)
			{
				m_pipedService = ServicesManager.CreatePipedService(Arguments.Instance, 5);

				if (!ServicesManager.IsOpened)
					m_pipedService.StartService();
			}
		}

		private void Run()
		{
			ServerInstance.Start(DESERVE.Arguments);

			if (DESERVE.Arguments.AutosaveMinutes > 0)
			{
				System.Timers.Timer autoSave = new System.Timers.Timer(DESERVE.Arguments.AutosaveMinutes * 60000);
				autoSave.AutoReset = true;
				autoSave.Elapsed += AutoSave;
				autoSave.Start();
			}

			if (DESERVE.Arguments.Plugins)
			{
				m_pluginManager.InitializeAllPlugins();
				System.Timers.Timer pluginUpdate = new System.Timers.Timer(_PLUGIN_UPDATE_FREQUENCY);
				pluginUpdate.AutoReset = true;
				pluginUpdate.Elapsed += m_pluginManager.Update;
				pluginUpdate.Start();
			}

			Console.WriteLine();
			Console.WriteLine("DESERVE: Server Loaded.");
			Console.WriteLine();
			Console.WriteLine("DESERVE: Press Escape to shut down server. F1 for more commands.");
			while (DedicatedServerWrapper.Program.IsRunning)
			{
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey(true);
					switch (key.Key)
					{
						case ConsoleKey.Escape:
							ServerInstance.Stop();
							break;
						case ConsoleKey.F1:
							Console.WriteLine("DESERVE: Commands");
							Console.WriteLine("    F1 - This help dialog.");
							Console.WriteLine("    HOME - Save world.");
							Console.WriteLine("    ESCAPE - Save and Shutdown.");
							break;
						case ConsoleKey.Home:
							Console.WriteLine("DESERVE: Saving World.");
							SandboxGameWrapper.WorldManager.EnhancedSave();
							break;
						default:
							break;
					}
				}
			}
		}

		private void AutoSave(object sender, ElapsedEventArgs e)
		{
			if (DedicatedServerWrapper.Program.IsRunning)
			{
				SandboxGameWrapper.WorldManager.EnhancedSave();
			}
		}
		#endregion
	}
}
