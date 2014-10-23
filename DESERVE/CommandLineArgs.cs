using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DESERVE
{
	public class CommandLineArgs
	{
		#region Fields
		#endregion

		#region Properties
		public Int32 AutosaveMinutes { get; set; }
		public Boolean Debug { get; set; }
		public String Instance { get; set; }
		public String LogDirectory { get; set; }
		public Boolean ModAPI { get; set; }
		public Boolean Plugins { get; set; }
		public Boolean Update { get; set; }
		public String UpdateNewPath { get; set; }
		public String UpdateOldPath { get; set; }
		public Boolean WCF { get; set; }
		#endregion

		public CommandLineArgs(string[] args)
		{
			// Set Defaults.
			AutosaveMinutes = -1;
			Debug = false;
			Instance = "";
			LogDirectory = Directory.GetCurrentDirectory() + "\\DESERVE";
			ModAPI = false;
			Plugins = false;
			Update = false;
			UpdateOldPath = "";
			UpdateNewPath = "";
			WCF = false;

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
							Instance = args[i + 1];
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
				}

				i++;
			}
		}

		public override string ToString()
		{
			return (Update ? "-update " + UpdateOldPath + " " + UpdateNewPath : "-autosave " + AutosaveMinutes.ToString() + " " + (Debug ? "-debug " : "") + "-instance \"" + Instance + "\" -logdir \"" + LogDirectory + "\" " + (ModAPI ? "-modapi " : "") + (Plugins ? "-plugins " : "") + (WCF ? "-wcf " : ""));
		}
	}
}
