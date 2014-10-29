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

			foreach (String instanceDir in instanceDirs)
			{
				String[] config = Directory.GetFiles(instanceDir, "SpaceEngineers-Dedicated.cfg");

				DirectoryInfo directoryInfo = new DirectoryInfo(instanceDir);

				if (config.Length == 1)
				{
					ServerInstances.Add(new ServerInstance(directoryInfo.Name));
				}
			}
		}
	}
}
