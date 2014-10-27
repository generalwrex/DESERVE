using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.Diagnostics;

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
		public Int32 AutosaveMinutes { get { return m_autosaveMinutes; }  set { m_autosaveMinutes = value; m_autosaveSet = true; } }
		public Boolean Debug { get; set; }
		public String Instance { get { return m_instance; } set { m_instance = value; m_instanceSet = true; } }
		public String LogDirectory { get { return m_logDirectory; } set { m_logDirectory = value; m_logDirectorySet = true; } }
		public Boolean ModAPI { get; set; }
		public Boolean Plugins { get; set; }
		public Boolean Update { get; set; }
		public String UpdateNewPath { get; set; }
		public String UpdateOldPath { get; set; }
		public Boolean WCF { get; set; }
		public Boolean VSDebug { get; set; }
		#endregion

		#region Methods
		public CommandLineArgs(string[] args) : this()
		{
			// Process Commandline.
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
					case "-modapi":
						ModAPI = true;
						break;
					case "-plugins":
						Plugins = true;
						break;
					case "-wcf":
						WCF = true;
						break;
					case "-vsdebug":
						if (Debugger.IsAttached == false)
							Debugger.Launch();
						break;
				}

				i++;
			}
		}
		public CommandLineArgs()
		{
			// Set Defaults.
			m_autosaveMinutes = -1;
			Debug = false;
			m_instance = "";
			m_logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "DESERVE");
			ModAPI = false;
			Plugins = false;
			Update = false;
			UpdateOldPath = "";
			UpdateNewPath = "";
			WCF = false;
		}

		public override string ToString()
		{
			return (Update ? "-update " + UpdateOldPath + " " + UpdateNewPath : (VSDebug ? "-vsdebug " : "") + (m_autosaveSet ? "-autosave " + AutosaveMinutes.ToString() + " " : "") + (Debug ? "-debug " : "") + (m_instanceSet ? "-instance \"" + Instance + "\" " : "") + (m_logDirectorySet ? "-logdir \"" + LogDirectory + "\" " : "") + (ModAPI ? "-modapi " : "") + (Plugins ? "-plugins " : "") + (WCF ? "-wcf " : ""));
		}
		#endregion
	}
}
