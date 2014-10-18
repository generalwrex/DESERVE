using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEEDS
{
	public class CommandLineArgs
	{
		public string AutostartWorld { get; set; }
		public bool debug { get; set; }

		public CommandLineArgs(string[] args)
		{
			// Set Defaults.
			AutostartWorld = "";
			debug = false;

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
						debug = true;
						break;
				}

				i++;
			}
		}
	}
}
