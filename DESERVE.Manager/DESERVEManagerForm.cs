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


using DESERVE.Manager.Marshall;

namespace DESERVE.Manager
{

	public partial class DESERVEManagerForm : Form
	{

		public DESERVEManagerForm()
		{
			InitializeComponent();
		
			GetServerInstances();
			
			this.Text = "DESERVE Manager v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

		}

		#region "Server Control"

		public void GetServerInstances()
		{
			try
			{
				List<Server> m_servers = InstanceManager.Instance.GetInstances;

				OLV_ServerInstances.AddObjects(m_servers);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("Exception: " + ex.Message);
			}
		}


		private void BTN_StartServer_Click(object sender, EventArgs e)
		{
			if (OLV_ServerInstances.SelectedObject != null)
			{
				var server = (Server)OLV_ServerInstances.SelectedObject;

				if (!server.IsRunning)
				{
					InstanceManager.Instance.StartServer(server.ArgumentsString);
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
				PG_CommandLineArgs.SelectedObject = new CommandLineProperties(server.Arguments);
			}
		}

		#endregion


	}

}
