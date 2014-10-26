using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

using DESERVE.Manager;

using DESERVE.Manager.Marshall;

namespace DESERVE.Managers
{
	public class InstanceManager
	{
		#region Fields
		private static InstanceManager m_instance;
		private List<string> m_instances;
		//private List<Server> m_servers;
		private ServerList<Server> m_servers;
		#endregion

		public delegate void ServerChangedHandler(Server server);
		public event ServerChangedHandler ServerChanged;

		#region Properties
		public static InstanceManager Instance
		{
			get 
			{
				if (m_instance == null)
					m_instance = new InstanceManager();

				return m_instance;
			}
		}

		public Server SelectedServer { get; set; }

		public ServerList<Server> GetInstances
		{
			get { return m_servers; }
		}
		#endregion

		#region Constructor
		public InstanceManager()
		{
			m_instance = this;

			m_instances = new List<string>();
			//m_servers = new List<Server>();
			m_servers = new ServerList<Server>();
			try
			{
				string commonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "SpaceEngineersDedicated");
				if (Directory.Exists(commonPath))
				{
					string[] subDirectories = Directory.GetDirectories(commonPath);
					foreach (string fullInstancePath in subDirectories)
					{
						string[] directories = fullInstancePath.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
						string instanceName = directories[directories.Length - 1];

						m_instances.Add(instanceName);
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}

			foreach (string instanceName in m_instances)
			{
				Server server = new Server();

				if (server.ConnectToServer(instanceName))
				{
					var marshall = server.Instance;
					var events = server.Events;


					var arguments = marshall.get_Arguments();
					server.IsRunning = marshall.get_IsRunning();
					server.Name = marshall.get_Name();
					server.Arguments = arguments;
					server.ArgumentsString = arguments.FullString;	
				}
				else
				{
					CommandLineArgs args = new CommandLineArgs();
					server.IsRunning = false;
					args.Instance = instanceName;
					args.AutosaveMinutes = -1;
					args.WCF = true;
					args.Debug = true;
					args.LogDirectory = @"F:\SteamLibrary\SteamApps\common\SpaceEngineers\DedicatedServer64\DESERVE\" + instanceName;

					server.Name = instanceName;
					server.Arguments = args;
					server.ArgumentsString = (args.Update ? "-update " + args.UpdateOldPath + " " + args.UpdateNewPath : "-autosave " + args.AutosaveMinutes.ToString() + " " + (args.Debug ? "-debug " : "") + "-instance \"" + args.Instance + "\" -logdir \"" + args.LogDirectory + "\" " + (args.ModAPI ? "-modapi " : "") + (args.Plugins ? "-plugins " : "") + (args.WCF ? "-wcf " : ""));
				}


				m_servers.Add(server);
			}


			foreach (object item in m_servers)
			{
				if (item is INotifyPropertyChanged)
				{
					INotifyPropertyChanged observable = (INotifyPropertyChanged)item;
					observable.PropertyChanged += new PropertyChangedEventHandler(ItemPropertyChanged);
				}
			}

		}

		private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			 var server = ((Server)sender);

			 if (ServerChanged != null) { ServerChanged(server); }

		}

		#endregion

		#region Methods
		public ProcessStartInfo StartServer(string argumentsString)
		{
			try
			{
				Process process = new Process();

				process.StartInfo.FileName = "DESERVE.exe";

				process.StartInfo.Arguments = argumentsString;
				process.StartInfo.Verb = "runas";

				process.Start();

				return process.StartInfo;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
				return null;
			}

		}
		#endregion

		
	}
}
