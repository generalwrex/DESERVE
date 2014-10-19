using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEEDSRemote.ServerManager;

namespace SEEDSRemote
{
	// Not Functional Yet, WCF Test, Tosses an exception right now, just wanted to get my commit up
	public partial class SEEDSRemoteForm : Form
	{

		private List<Server> m_servers;

		private ServerManagerClient m_serverManagerClient;

		public SEEDSRemoteForm()
		{
			InitializeComponent();

			m_serverManagerClient = new ServerManagerClient();

			ServerInstance[] m_serverInstances = m_serverManagerClient.GetServerInstances();

			m_servers = new List<Server>();

			m_servers.Add(new Server("Created 2014-09-19 1340"));
			OLV_ServerInstances.AddObjects(m_servers);


		}

		private void BTN_StartServer_Click(object sender, EventArgs e)
		{
			if (OLV_ServerInstances.SelectedObject != null)
				m_serverManagerClient.StartServer(((Server)OLV_ServerInstances.SelectedObject).SaveFile);
		}

		private void BTN_StopServer_Click(object sender, EventArgs e)
		{

		}

		private void BTN_StopAllServers_Click(object sender, EventArgs e)
		{

		}
	}

	class Server
	{
		private string saveFile;

		public string SaveFile { get { return saveFile; } set { saveFile = value; } }

		public Server(string saveFile)
		{
			this.SaveFile = saveFile;
		}
	}
}
