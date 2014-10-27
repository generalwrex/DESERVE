using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DESERVE.Manager.Dialogs
{
	public partial class ManagerException : Form
	{
		public ManagerException(Exception exception)
		{
			InitializeComponent();

			this.Text = "DESERVE Manager Exception";

			BTN_ManagerException_GenerateReport.Enabled = false;

			TXT_ManagerException_Message.Text = exception.Message;
			TXT_ManagerException_Error.Text = exception.ToString();

			this.ShowDialog();
		}

		private void BTN_ManagerException_GenerateReport_Click(object sender, EventArgs e)
		{
			
		}

		private void BTN_ManagerException_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}



	}
}
