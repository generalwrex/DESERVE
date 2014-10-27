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
using DESERVE.Common;
using DESERVE.Manager.Managers;
using System.Windows.Forms;

namespace DESERVE.Managers
{
	public class InstanceManager
	{
		#region Fields
		private static InstanceManager m_instance;
		private List<string> m_instances;
		private ServerList<Server> m_servers;
		#endregion

		#region Events
		public delegate void ServerChangedHandler(Server server);
		public event ServerChangedHandler ServerChanged;
		#endregion

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
		public ServerList<Server> GetInstances { get { return m_servers; } }

		public string CommonDataPath { 
			get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "SpaceEngineersDedicated"); } }
		#endregion

		#region Constructor
		public InstanceManager()
		{
			m_instance = this;
			m_instances = new List<string>();
			m_servers = new ServerList<Server>();

			GetInstanceNames();
			InitialGetServers();
			RefreshPropertyEventHandlers();
		}
		#endregion

		#region EventHandlers
		private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			 var server = ((Server)sender);

			 if (ServerChanged != null) { ServerChanged(server); }

		}
		#endregion

		#region Methods
		private void GetInstanceNames()
		{
			try
			{
				if (Directory.Exists(CommonDataPath))
				{
					foreach (string fullInstancePath in Directory.GetDirectories(CommonDataPath))
					{
						string[] directories = fullInstancePath.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
						string instanceName = directories[directories.Length - 1];

						m_instances.Add(instanceName);
					}
				}
			}
			catch (Exception ex)
			{
				new Manager.Dialogs.ManagerException(ex);
			}
		}

		private void InitialGetServers()
		{
			foreach (string instanceName in m_instances)
			{

				try
				{
					Server server = new Server();

					if (server.ConnectToServer(instanceName))
					{
						var marshall = server.Instance;
						var events = server.Events;

						var arguments = marshall.Arguments;

						server.IsRunning = marshall.IsRunning;
						server.Arguments = arguments;

						FileManager.Instance.SaveInstanceConfiguration(server);
					}
					else
					{


						CommandLineArgs args = new CommandLineArgs();
						server.IsRunning = false;
						args.Instance = instanceName;
						args.AutosaveMinutes = -1;
						args.WCF = true;
						args.Debug = true;
						args.VSDebug = true;

						server.Arguments = args;
						FileManager.Instance.SaveInstanceConfiguration(server);
					}

					m_servers.Add(server);
				}
				catch (Exception ex)
				{
					new Manager.Dialogs.ManagerException(ex);
				}		
			}
		}

		public void RefreshPropertyEventHandlers()
		{
			try
			{
				foreach (object item in m_servers)
				{
					if (item is INotifyPropertyChanged)
					{
						INotifyPropertyChanged observable = (INotifyPropertyChanged)item;
						observable.PropertyChanged -= ItemPropertyChanged;
						observable.PropertyChanged += new PropertyChangedEventHandler(ItemPropertyChanged);
					}
				}
			}
			catch (Exception ex)
			{
				new Manager.Dialogs.ManagerException(ex);
			}
		}

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
			catch (Exception)
			{
				MessageBox.Show(null, "Please make sure the path to DESERVE is set properly in the 'Manager Configuration' Tab!",
					"DESERVE.exe Not Found", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return null;
			}

		}
		#endregion

		
	}
}
