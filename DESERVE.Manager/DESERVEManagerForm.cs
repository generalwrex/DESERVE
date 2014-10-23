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

namespace DESERVE.Manager
{
	
	public partial class DESERVEManagerForm : Form
	{

		private List<Server> m_servers;
		private Server m_server;

		public DESERVEManagerForm()
		{
			InitializeComponent();
			m_servers = new List<Server>();

			//m_server = new Server();
			//m_server.ConnectToServer(TXT_InstanceName.Text);

			//m_servers.Add(server);

			//OLV_ServerInstances.AddObjects(m_servers);

		}

		private void BTN_StartServer_Click(object sender, EventArgs e)
		{
			if (OLV_ServerInstances.SelectedObject != null)
			{

			}
		}

		private void BTN_StopServer_Click(object sender, EventArgs e)
		{
			m_server.StopServer();

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
			m_server.Save();
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
			try
			{
				m_server = new Server();
				m_server.ConnectToServer(TXT_InstanceName.Text);

				TXT_InfoBox.Text = "Name:" + m_server.Name + "\r\n";
				TXT_InfoBox.Text += "IsRunning:" + m_server.IsRunning + "\r\n";
				TXT_InfoBox.Text += "Args:" + m_server.Arguments.ToString() + "\r\n";
			}
			catch (Exception ex)
			{

				TXT_InfoBox.Text = "Exception: " + ex.Message;
			}

		}
	}


}
