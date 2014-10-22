using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DESERVE.Manager.ServerMarshalClient;

namespace DESERVE.Manager
{
	
	public partial class DESERVEManagerForm : Form
	{

		private ServerMarshallClient m_marshallClient;

		public DESERVEManagerForm()
		{
			InitializeComponent();

			m_marshallClient = new ServerMarshallClient();

			//ServerInstance[] m_serverInstances = m_serverManagerClient.GetServerInstances();

			//m_servers = new List<Server>();

			//m_servers.Add(new Server("Created 2014-09-19 1340"));
			//OLV_ServerInstances.AddObjects(m_servers);

		}

		private void BTN_StartServer_Click(object sender, EventArgs e)
		{
			//CommandLineArgs args = new CommandLineArgs();
			//m_marshallClient.Start(args);
		}

		private void BTN_StopServer_Click(object sender, EventArgs e)
		{
			m_marshallClient.Stop();
		}


		private void BTN_Save_Click(object sender, EventArgs e)
		{
			m_marshallClient.Save();
		}
	}


}
