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

using DESERVE.Managers;

using DESERVE.Manager.Marshall;

namespace DESERVE.Manager
{

	public partial class DESERVEManagerForm : Form
	{

		public DESERVEManagerForm()
		{
			InitializeComponent();

			try
			{
				List<Server> m_servers = InstanceManager.Instance.GetInstances;

				OLV_ServerInstances.AddObjects(m_servers);
				//PG_CommandLineArgs.SelectedObject = new CommandLineProperties();
			}
			catch (Exception ex)
			{

				TXT_InfoBox.Text = "Exception: " + ex.Message;
			}

			


			this.Text = "DESERVE Manager v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

		}

		private void BTN_StartServer_Click(object sender, EventArgs e)
		{
			if (OLV_ServerInstances.SelectedObject != null)
			{
				var server = (Server)OLV_ServerInstances.SelectedObject;

				if (!server.IsRunning)
				{
					ProcessManager.StartServer(server.ArgumentsString);
				}
			}
		}

		private void BTN_StopServer_Click(object sender, EventArgs e)
		{
			//m_server.StopServer();

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
			//m_server.Save();
			if (OLV_ServerInstances.SelectedObject != null)
			{
				var server = (Server)OLV_ServerInstances.SelectedObject;
				if (server.IsRunning)
				{
					server.Save();
				}
			}
		}

		private void BTN_TestConnect_Click(object sender, EventArgs e)
		{
		}
	}


}
