using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SEEDS
{
	class LogManager
	{
		#region Fields
		private const String _ERROR_LOG_NAME = "SEEDS_Error.log";
		private const String _MAIN_LOG_NAME = "SEEDS.log";

		private String m_logDirectory;
		#endregion

		#region Properties
		public String LogDirectory { get { return m_logDirectory; } set { m_logDirectory = value; } }

		static public LogInstance ErrorLog { get; set; }
		static public LogInstance MainLog { get; set; }
		#endregion

		#region Methods
		public LogManager(String logDirectory)
		{
			m_logDirectory = logDirectory;
			ErrorLog = new LogInstance(m_logDirectory, _ERROR_LOG_NAME);
			MainLog = new LogInstance(m_logDirectory, _MAIN_LOG_NAME);
		}
		#endregion
	}

	class LogInstance
	{
		#region Fields
		private String m_logFile;
		private StringBuilder m_StringBuilder;
		private static readonly object _logLock = new object();
		#endregion

		#region Properties
		#endregion

		#region Methods
		public LogInstance(String logDirectory, String logName)
		{
			if (!Directory.Exists(logDirectory))
			{
				try
				{
					Directory.CreateDirectory(logDirectory);
				}
				catch (Exception ex)
				{
					LogManager.ErrorLog.WriteLineAndConsole("Failed to create log directory " + logDirectory + " - " + ex.Message);
					throw;
				}
			}

			m_logFile = logDirectory + "\\" + logName;
		}

		public void WriteLine(String message)
		{
			if (m_logFile != null)
			{
				try
				{

				}
				catch (Exception ex)
				{
					Console.WriteLine("Failed to write to log: " + ex.Message);
				}
			}
		}

		public void WriteLineAndConsole(String message)
		{
			Console.WriteLine(message);
			WriteLine(message);
		}
		#endregion
	}
}
