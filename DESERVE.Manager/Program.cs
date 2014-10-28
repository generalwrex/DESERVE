using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;

namespace DESERVE.Manager
{
	static class Program
	{
		#region Properties
		static public Version Version { get { return Assembly.GetEntryAssembly().GetName().Version; } }
		static public String BuildBranch { get { return "Dev"; } }
		static public String VersionString { get { return Version.ToString(3) + " " + BuildBranch; } }
		static public Boolean VSDebug { get; set; }
		#endregion


		private static bool IsAdministrator()
		{
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length == 1)
			{
				if (args[0] == "-vsdebug")
					VSDebug = true;
			}

			if (IsAdministrator() == false)
			{
				// Restart program and run as admin
				var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
				ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
				startInfo.Verb = "runas";
				System.Diagnostics.Process.Start(startInfo);
				Application.Exit();
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DESERVEManagerForm());
		}
	}
}
