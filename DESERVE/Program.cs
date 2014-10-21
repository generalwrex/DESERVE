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

namespace DESERVE //DEdicated SERVer, Enhanced
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
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			DESERVE program = new DESERVE(args);

			LogManager.MainLog.WriteLineAndConsole("DESERVE " + VersionString);
			program.Run();
			LogManager.MainLog.WriteLineAndConsole("DESERVE Shutting Down.");
		}

		public DESERVE(string[] args)
		{
			m_commandLineArgs = new CommandLineArgs(args);
			m_logManager = new LogManager(m_commandLineArgs.LogDirectory);
		}

		private void Run()
		{
			ServerInstance.Start(m_commandLineArgs);

			if (m_commandLineArgs.AutosaveMinutes > 0)
			{
				System.Timers.Timer autoSave = new System.Timers.Timer(m_commandLineArgs.AutosaveMinutes * 60000);
				autoSave.AutoReset = true;
				autoSave.Elapsed += AutoSave;
				autoSave.Start();
			}

			Console.WriteLine();
			Console.WriteLine("Server Loaded.");
			Console.WriteLine();
			Console.WriteLine("Press Escape to shut down server. F1 for more commands.");
			while (ServerInstance.IsRunning)
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
							Console.WriteLine("F1 - This help dialog.");
							Console.WriteLine("HOME - Save world.");
							Console.WriteLine("ESCAPE - Save and Shutdown.");
							break;
						case ConsoleKey.Home:
							Console.WriteLine("Saving World.");
							SandboxGameWrapper.WorldManager.Save();
							break;
						default:
							break;
					}
				}
			}
		}

		private void AutoSave(object sender, ElapsedEventArgs e)
		{
			if (ServerInstance.IsRunning)
			{
				ServerInstance.Save();
			}
		}
		#endregion
	}
}
