using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Design;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DESERVE.Common
{
	public class CommandLineArgs
	{
		#region Fields
		private Boolean m_autosaveSet;
		private Boolean m_instanceSet;
		private Boolean m_logDirectorySet;

		private Int32 m_autosaveMinutes;
		private String m_instance;
		private String m_logDirectory;

		#endregion

		#region Properties
		[Browsable(true)]
		[ReadOnly(false)]
		[Category("Command Line Arguments")]
		[DisplayName("Autosave (In Minutes")]
		[Description("How often the server saves in Minutes ( set to -1 to disable autosave).")]
		public Int32 AutosaveMinutes { get { return m_autosaveMinutes; }  set { m_autosaveMinutes = value; m_autosaveSet = true; } }

		[Browsable(true)]
		[ReadOnly(false)]
		[Category("Command Line Arguments")]
		[DisplayName("Enable Debugging")]
		[Description("Enable verbose debugging in the console.")]
		public Boolean Debug { get; set; }

		[Browsable(true)]
		[ReadOnly(true)]
		[Category("Command Line Arguments")]
		[DisplayName("Instance Name")]	
		[Description("The name of the instance to load.")]
		public String Instance { get { return m_instance; } set { m_instance = value; m_instanceSet = true; } }

		[Browsable(true)]
		[ReadOnly(false)]
		[Category("Command Line Arguments")]
		[DisplayName("Log Directory")]
		[Description("The directory for DESERVE logs.")]
		[EditorAttribute(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public String LogDirectory { get { return m_logDirectory; } set { m_logDirectory = value; m_logDirectorySet = true; } }

		[Browsable(true)]
		[ReadOnly(false)]
		[Category("Command Line Arguments")]
		[DisplayName("Enable Plugins")]
		[Description("Enable DESERVE Plugins.")]
		public Boolean Plugins { get; set; }

		[Browsable(false)]
		public Boolean Update { get; set; }

		[Browsable(false)]
		public String UpdateNewPath { get; set; }

		[Browsable(false)]
		public String UpdateOldPath { get; set; }

		[Browsable(true)]
		[ReadOnly(false)]
		[Category("Command Line Arguments")]
		[DisplayName("Enable WCF")]
		[Description("Required for Communication with DESERVE")]
		public Boolean WCF { get; set; }

		[Browsable(true)]
		[ReadOnly(false)]
		[Category("Command Line Arguments")]
		[DisplayName("Enable VS Debug")]
		[Description("Allow Visual Studio to debug the server.")]
		public Boolean VSDebug { get; set; }
		#endregion

		#region Methods

		public CommandLineArgs(String args)
			: this(SeperateArgs(args))
		{
		}

		public CommandLineArgs(String[] args) 
			: this()
		{
			// Process Commandline.
			ProcessArgArray(args);
		}

		public CommandLineArgs()
		{
			// Set Defaults.
			m_autosaveMinutes = -1;
			Debug = false;
			m_instance = "";
			m_logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "DESERVE");
			Plugins = false;
			Update = false;
			UpdateOldPath = "";
			UpdateNewPath = "";
			WCF = false;
		}

		public override string ToString()
		{
			return (Update ? "-update " + UpdateOldPath + " " + UpdateNewPath : (VSDebug ? "-vsdebug " : "") + (m_autosaveSet ? "-autosave " + AutosaveMinutes.ToString() + " " : "") + (Debug ? "-debug " : "") + (m_instanceSet ? "-instance \"" + Instance + "\" " : "") + (m_logDirectorySet ? "-logdir \"" + LogDirectory + "\" " : "") + (Plugins ? "-plugins " : "") + (WCF ? "-wcf " : ""));
		}

		private static String[] SeperateArgs(String argString)
		{
			MatchCollection matches = Regex.Matches(argString, "(-\\S*|\"[\\s\\S]*\")");

			string[] argArray = new String[matches.Count];

			int i = 0;

			foreach (Match match in matches)
			{
				argArray[i] = match.Value;
				i++;
			}

			return argArray;
		}

		private void ProcessArgArray(string[] args)
		{
			int numArgs = args.GetLength(0);
			int i = 0;
			while (numArgs != i)
			{
				string currentArg = args[i].ToLower();
				switch (currentArg)
				{
					case "-autosave":
						if (i + 1 != numArgs)
						{
							Int32 autoSave;
							if (Int32.TryParse(args[i + 1], out autoSave))
							{
								AutosaveMinutes = autoSave;
								m_autosaveSet = true;
								i++;
							}
							else
							{
								Console.WriteLine("Argument Error: -autosave duration \"" + args[i + 1] + "\" invalid.");
							}
						}
						else
						{
							Console.WriteLine("Argument Error: -autosave duration not specified.");
						}
						break;
					case "-debug":
						Debug = true;
						break;
					case "-instance":
						if (i + 1 != numArgs)
						{
							Instance = args[i + 1];
							m_instanceSet = true;
							i++;
						}
						else
						{
							Console.WriteLine("Argument Error: -autostart world not specified.");
						}
						break;
					case "-logdir":
						if (i + 1 != numArgs)
						{
							LogDirectory = args[i + 1];
							m_logDirectorySet = true;
							i++;
						}
						else
						{
							Console.WriteLine("Argument Error: -logdir directory not specified.");
						}
						break;
					case "-plugins":
						Plugins = true;
						break;
					case "-wcf":
						WCF = true;
						break;
					case "-vsdebug":
						Debugger.Launch();
						break;
				}

				i++;
			}
		}
		#endregion
	}
}
