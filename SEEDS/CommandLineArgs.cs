using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SEEDS
{
	public class CommandLineArgs
	{
		#region Fields
		#endregion

		#region Properties
		public string AutostartWorld { get; set; }
		public bool Debug { get; set; }
		public string LogDirectory { get; set; }
		#endregion

		public CommandLineArgs(string[] args)
		{
			// Set Defaults.
			AutostartWorld = "";
			Debug = false;
			LogDirectory = Directory.GetCurrentDirectory() + "\\SEEDS";

			// Process Commandline.
			int numArgs = args.GetLength(0);
			int i = 0;
			while (numArgs != i)
			{
				string currentArg = args[i].ToLower();
				switch (currentArg)
				{
					case "-autostart":
						if (i + 1 != numArgs)
						{
							AutostartWorld = args[i + 1];
							i++;
						}
						else
						{
							Console.WriteLine("Argument Error: -autostart world not specified.");
						}
						break;
					case "-debug":
						Debug = true;
						break;
				}

				i++;
			}
		}

	}
}
