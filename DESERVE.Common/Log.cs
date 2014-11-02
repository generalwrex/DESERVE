using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace DESERVE.Common
{
	public class Log
	{
		#region Fields
		private String m_logFile;
		private StringBuilder m_stringBuilder;
		private String m_logDirectory;
		private String m_logName;
		private Boolean m_initialized;

		private static readonly object _logLock = new object();
		#endregion

		#region Properties
		#endregion

		#region Methods
		public Log(String logDirectory, String logName)
		{
			m_logDirectory = logDirectory;
			m_logName = logName;
			m_initialized = false;
		}

		private void Init()
		{
			if (!Directory.Exists(m_logDirectory))
			{
				try
				{
					Directory.CreateDirectory(m_logDirectory);
				}
				catch (Exception ex)
				{
					Console.WriteLine(String.Format("Failed to create log directory {0} - {1}", m_logDirectory, ex.Message));
				}
			}
			m_stringBuilder = new StringBuilder();
			m_logFile = Path.Combine(m_logDirectory, m_logName);
			if (File.Exists(m_logFile))
			{
				FileInfo oldLog = new FileInfo(m_logFile);
				String oldLogName = Path.Combine(m_logDirectory, Path.GetFileNameWithoutExtension(oldLog.FullName));

				DateTime logCreated = oldLog.LastWriteTime;

				oldLogName += logCreated.ToString("_yyyy_MMM_dd_HHmm_ss");
				oldLogName += ".log";

				File.Move(oldLog.FullName, oldLogName);
			}
			m_initialized = true;
			WriteLine("Log File Opened.");
		}

		public void WriteLine(String message)
		{
			if (!m_initialized)
			{
				Init();
			}

			if (m_logFile != null)
			{
				try
				{
					TextWriter m_Writer = new StreamWriter(m_logFile, true);
					TextWriter.Synchronized(m_Writer).WriteLine(String.Format("{0} - Thread: {1} -> {2}", Timestamp(), ThreadInfo(), message));
					m_Writer.Close();
				}
				catch (Exception ex)
				{
					Console.WriteLine(String.Format("Failed to write to log: {0}", ex.Message));
				}
			}
		}

		public void WriteLineAndConsole(String message)
		{
			Console.WriteLine(String.Format("{0}: {1}", Timestamp(), message));
			WriteLine(message);
		}

		private String Timestamp()
		{
			DateTimeOffset now = DateTimeOffset.Now;
			return now.ToString("yyyy-MM-dd HH.mm:ss.fff");
		}

		private String ThreadInfo()
		{
			return Thread.CurrentThread.ManagedThreadId.ToString();
		}
		#endregion
	}
}
