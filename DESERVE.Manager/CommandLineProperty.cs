using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;

using DESERVE.Manager.Marshall;

namespace DESERVE
{
	public class CommandLineProperties
	{
		#region Properties
		[Category("Command Line Arguments")]
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("")]
		public Int32 AutosaveMinutes { get; set; }

		[Category("Command Line Arguments")]
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("")]
		public Boolean Debug { get; set; }

		[Category("Command Line Arguments")]
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("")]
		public String Instance { get; set; }

		[Category("Command Line Arguments")]
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("")]
		public String LogDirectory { get; set; }

		[Category("Command Line Arguments")]
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("")]
		public Boolean ModAPI { get; set; }

		[Category("Command Line Arguments")]
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("")]
		public Boolean Plugins { get; set; }

		[Category("Command Line Arguments")]
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("")]
		public Boolean WCF { get; set; }
		#endregion

		#region Constructor
		public CommandLineProperties(CommandLineArgs args)
		{
			AutosaveMinutes = args.AutosaveMinutes;
			Debug = args.Debug;
			Instance = args.Instance;
			LogDirectory = args.LogDirectory;
			ModAPI = args.ModAPI;
			Plugins = args.Plugins;
			WCF = args.WCF;
		}

		
		#endregion
	}
}
