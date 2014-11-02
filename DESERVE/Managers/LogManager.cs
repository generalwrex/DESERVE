using DESERVE.Common;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace DESERVE.Managers
{
	internal class LogManager
	{
		#region Fields
		private const String _ERROR_LOG_NAME = "DESERVE_Error.log";
		private const String _MAIN_LOG_NAME = "DESERVE.log";
		private const String _CHAT_LOG_NAME = "DESERVE_Chat.log";

		private String m_logDirectory;
		#endregion

		#region Properties
		public String LogDirectory { get { return m_logDirectory; } set { m_logDirectory = value; } }

		static public Log ErrorLog { get; set; }
		static public Log MainLog { get; set; }
		static public Log ChatLog { get; set; }

		#endregion

		#region Methods
		public LogManager(String logDirectory)
		{
			m_logDirectory = logDirectory;
			ErrorLog = new Log(m_logDirectory, _ERROR_LOG_NAME);
			MainLog = new Log(m_logDirectory, _MAIN_LOG_NAME);
			ChatLog = new Log(m_logDirectory, _CHAT_LOG_NAME);
		}
		#endregion
	}
}
