using System;
using System.Diagnostics;

using System.Windows.Forms;

using DESERVE.Manager.Marshall;

namespace DESERVE.Managers
{
	internal static class ProcessManager
	{

		public static ProcessStartInfo StartServer(string argumentsString)
		{
			try
			{
				Process process = new Process();

				process.StartInfo.FileName = "DESERVE.exe";

				process.StartInfo.Arguments = argumentsString;
				process.StartInfo.Verb = "runas";

				process.Start();

				return process.StartInfo;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
			
		}

	}
}
