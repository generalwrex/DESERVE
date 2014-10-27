using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.Threading;
using System.IO;
using System.Security.Principal;

using DESERVE.Manager.Properties;
using DESERVE.Manager.Managers;
using DESERVE.Common;


namespace DESERVE.Manager
{

	public partial class DESERVEManagerForm : Form
	{
		#region Fields
		private CommandLineArgs m_beforeChanges;
		private Dictionary<string, Server> m_serverDict;
		#endregion

		public DESERVEManagerForm()
		{
			m_serverDict = new Dictionary<string, Server>();

			InitializeComponent();	
			GetServerInstances();

			this.Text = "DESERVE Manager v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			
			InstanceManager.Instance.ServerChanged += Instance_ServerChanged;

			// load manager defaults
			InstanceManager.Instance.DeservePath = Settings.Default.DESERVEPath;
			TXT_ManagerConfiguration_DESERVEPath.Text = Settings.Default.DESERVEPath;

			if (Settings.Default.FirstRun)
			{
				TAB_MainTabs.SelectedTab = TAB_ManagerConfig_Page;
				Settings.Default.FirstRun = false;
				Settings.Default.Save();
			}


			
		}

		void Events_ReceivedChatMessage(ulong remoteUserId, string message)
		{
			TXT_Chat_Messages.Lines[TXT_Chat_Messages.Lines.Length - 1] += remoteUserId + " [" + InstanceManager.Instance.SelectedServer + "]: " + message + "\r\n";
		}

		// fires off if something in a Server instance is changed
		void Instance_ServerChanged(Server server)
		{
			OLV_ServerInstances.RefreshObject(server);
			
		}

		#region General
		private void CMB_SelectedInstance_SelectedIndexChanged(object sender, EventArgs e)
		{
			Server server;
			m_serverDict.TryGetValue(CMB_SelectedInstance.SelectedItem.ToString(), out server);

			OLV_ServerInstances.SelectedObject = server;
			InstanceManager.Instance.SelectedServer = server;
		}
		#endregion


		#region "Server Control"

		public void GetServerInstances()
		{
			try
			{
				ServerList<Server> m_servers = InstanceManager.Instance.GetInstances;
				OLV_ServerInstances.AddObjects(m_servers);

				foreach(Server server in m_servers)
				{
					m_serverDict[server.Name] = server;
					CMB_SelectedInstance.Items.Add(server.Name);
				}
				
			}
			catch (Exception ex)
			{
				new Dialogs.ManagerException(ex);
			}
		}


		private void BTN_StartServer_Click(object sender, EventArgs e)
		{
			if (OLV_ServerInstances.SelectedObject != null)
			{
				var server = (Server)OLV_ServerInstances.SelectedObject;

				if (!server.IsRunning)
				{
					InstanceManager.Instance.StartServer(server.Arguments.ToString());
				}
			}
		}

		private void BTN_StopServer_Click(object sender, EventArgs e)
		{

			if (OLV_ServerInstances.SelectedObject != null)
			{
				var server = (Server)OLV_ServerInstances.SelectedObject;
				if (server.IsRunning)
				{
					server.StopServer();
				}
			}
		}

		private void BTN_Save_Click(object sender, EventArgs e)
		{
			if (OLV_ServerInstances.SelectedObject != null)
			{
				var server = (Server)OLV_ServerInstances.SelectedObject;
				if (server.IsRunning)
				{
					server.Save();
				}
			}
		}

		private void OLV_ServerInstances_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (OLV_ServerInstances.SelectedObject != null)
			{
				var server = (Server)OLV_ServerInstances.SelectedObject;

				CMB_SelectedInstance.SelectedItem = server.Name;
				m_statusBar.Text = String.Format("Selected '{0}' Instance", server.Name);

				InstanceManager.Instance.SelectedServer= server;

				PG_CommandLineArgs.SelectedObject = server.Arguments;
			}
		}

		#endregion


		#region Manager Configuration

		private void BTN_ManagerConfiguration_Browse_Click(object sender, EventArgs e)
		{
			DIALOG_ManagerConfiguration_DESERVEPath.ShowDialog(this);

			string deservePath = DIALOG_ManagerConfiguration_DESERVEPath.SelectedPath;

			if (File.Exists(Path.Combine(deservePath, "DESERVE.exe") ))
			{
				InstanceManager.Instance.DeservePath = deservePath;
				TXT_ManagerConfiguration_DESERVEPath.Text = deservePath;

				Settings.Default.DESERVEPath = deservePath;
				Settings.Default.Save();
			}
			else
			{
				m_statusBar.Text = "Could not find DESERVE.exe in the Selected Path";
			}
					
		}

		private void TXT_ManagerConfiguration_DESERVEPath_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				string deservePath = TXT_ManagerConfiguration_DESERVEPath.Text;

				if (File.Exists(Path.Combine(deservePath, "DESERVE.exe")))
				{
					InstanceManager.Instance.DeservePath = deservePath;
					DIALOG_ManagerConfiguration_DESERVEPath.SelectedPath = deservePath;
					Settings.Default.DESERVEPath = deservePath;
					Settings.Default.Save();
				}
				else
				{
					m_statusBar.Text = "Could not find DESERVE.exe in the Selected Path";
				}

			}
		}

		#endregion

		#region Instance Configuration

		private void BTN_InstanceConfiguration_Cancel_Click(object sender, EventArgs e)
		{		
		}

		private void BTN_InstanceConfiguration_Save_Click(object sender, EventArgs e)
		{
			var server = InstanceManager.Instance.SelectedServer;
			server.Arguments = (CommandLineArgs)PG_CommandLineArgs.SelectedObject;

			FileManager.Instance.SaveInstanceConfiguration(server);
			OLV_ServerInstances.RefreshObject(server);

			m_statusBar.Text = "Changes Saved - Restart '" + server.Name + "' for updated changes";
		}

		#endregion

		private void PG_CommandLineArgs_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if(m_beforeChanges == null)
				m_beforeChanges = (CommandLineArgs)PG_CommandLineArgs.SelectedObject;
		}

		#region Chat

		private void BTN_Chat_SendMessage_Click(object sender, EventArgs e)
		{

		}

		private void BTN_Chat_Broadcast_Click(object sender, EventArgs e)
		{

		}
		#endregion




	}

}
