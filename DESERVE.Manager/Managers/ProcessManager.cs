using System;
using System.Diagnostics;

using System.Windows.Forms;

namespace DESERVE.Managers
{
	internal static class ProcessManager
	{

		public static ProcessStartInfo StartServer(CommandLineArgs args)
		{
			try
			{
				Process process = new Process();

				process.StartInfo.FileName = "DESERVE.exe";
				process.StartInfo.Arguments = args.ToString();
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
