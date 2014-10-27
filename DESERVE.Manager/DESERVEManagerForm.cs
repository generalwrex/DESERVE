using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DESERVE.Managers;
using System.Reflection;
using System.Threading;
using System.IO;

namespace DESERVE.Manager
{

	public partial class DESERVEManagerForm : Form
	{

		public DESERVEManagerForm()
		{
			InitializeComponent();
		
			GetServerInstances();
			
			this.Text = "DESERVE Manager v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

			InstanceManager.Instance.ServerChanged += Instance_ServerChanged;
		}

		// fires off if something in a Server instance is changed
		void Instance_ServerChanged(Server server)
		{
			OLV_ServerInstances.RefreshObject(server);
		}

		#region "Server Control"

		public void GetServerInstances()
		{
			try
			{
				ServerList<Server> m_servers = InstanceManager.Instance.GetInstances;
				OLV_ServerInstances.AddObjects(m_servers);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Exception: " + ex.ToString());
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

				LBL_CurrentlyManaging.Text = server.Name;

				InstanceManager.Instance.SelectedServer= server;

				PG_CommandLineArgs.SelectedObject = server.Arguments;
			}
		}

		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			OLV_ServerInstances.ClearObjects();
			GetServerInstances();
		}


	}

}
