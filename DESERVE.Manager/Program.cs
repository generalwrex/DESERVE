﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DESERVEManagerForm());
		}
	}
}
