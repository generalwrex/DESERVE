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

			if (m_commandLineArgs.AutosaveSeconds > 0)
			{
				System.Timers.Timer autoSave = new System.Timers.Timer(m_commandLineArgs.AutosaveSeconds * 1000);
				autoSave.AutoReset = true;
				autoSave.Elapsed += AutoSave;
				autoSave.Start();
			}
			String input = null;
			Boolean quit = false;
			while (!quit)
			{
				input = Console.ReadLine();

				switch (input)
				{
					case "save":
						SandboxGameWrapper.WorldManager.Save();
						break;
						
					case "stop":
						ServerInstance.Stop();
						break;

					case "start":
						ServerInstance.Start(m_commandLineArgs);
						break;

					case "quit":
						quit = true;
						break;
				}
				input = null;
			}
		}

		private void AutoSave(object sender, ElapsedEventArgs e)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
