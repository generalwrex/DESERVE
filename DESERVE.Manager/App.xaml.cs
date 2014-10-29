using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DESERVE.Manager
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class Manager : Application
	{
		private static String _SE_INSTANCE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "SpaceEngineersDedicated");

		public static List<ServerInstance> ServerInstances { get; set; }

		public Manager()
		{
			ServerInstances = new List<ServerInstance>();

			String[] args = Environment.GetCommandLineArgs();
			String[] instanceDirs = Directory.GetDirectories(_SE_INSTANCE_PATH);

			// Get Instances
			foreach (String instanceDir in instanceDirs)
			{
				// Find the configuration file.
				String[] config = Directory.GetFiles(instanceDir, "SpaceEngineers-Dedicated.cfg");

				if (config.Length == 1)
				{
					// Instance found. Create and add it.
					DirectoryInfo directoryInfo = new DirectoryInfo(instanceDir);
					ServerInstances.Add(new ServerInstance(instanceDir, directoryInfo.Name));
				}
			}
		}
	}
}
