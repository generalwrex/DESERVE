using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace DESERVE.Managers
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
		private StringBuilder m_stringBuilder;
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
			m_stringBuilder = new StringBuilder();
			m_logFile = logDirectory + "\\" + logName;
		}

		public void WriteLine(String message)
		{
			if (m_logFile != null)
			{
				try
				{
					TextWriter m_Writer = new StreamWriter(m_logFile, true);
					TextWriter.Synchronized(m_Writer).WriteLine(message);
					m_Writer.Close();
						
				}
				catch (Exception ex)
				{
					Console.WriteLine("Failed to write to log: " + ex.Message);
				}
			}
		}

		public void WriteLineAndConsole(String message)
		{
			message = FormatMessage(message);
			Console.WriteLine(message);
			WriteLine(message);
		}

		private String FormatMessage(String message)
		{
			lock (_logLock)
			{
				m_stringBuilder.Clear();
				AppendTimestamp();
				m_stringBuilder.Append(" - ");
				AppendThreadInfo();
				m_stringBuilder.Append(" -> ");
				m_stringBuilder.Append(message);
				message = m_stringBuilder.ToString();
				m_stringBuilder.Clear();
			}
			return message;
		}

		private void AppendThreadInfo()
		{
			m_stringBuilder.Append("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString());
		}

		private void AppendTimestamp()
		{
			DateTimeOffset now = DateTimeOffset.Now;
			StringBuilderExtensions.Concat(m_stringBuilder, now.Year, 4U, '0', 10U, false).Append('-');
			StringBuilderExtensions.Concat(m_stringBuilder, now.Month, 2U).Append('-');
			StringBuilderExtensions.Concat(m_stringBuilder, now.Day, 2U).Append(' ');
			StringBuilderExtensions.Concat(m_stringBuilder, now.Hour, 2U).Append(':');
			StringBuilderExtensions.Concat(m_stringBuilder, now.Minute, 2U).Append(':');
			StringBuilderExtensions.Concat(m_stringBuilder, now.Second, 2U).Append('.');
			StringBuilderExtensions.Concat(m_stringBuilder, now.Millisecond, 3U);
		}
		#endregion
	}
}
