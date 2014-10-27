namespace DESERVE.Manager.Dialogs
{
	partial class ManagerException
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.BTN_ManagerException_GenerateReport = new System.Windows.Forms.Button();
			this.BTN_ManagerException_Close = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.TXT_ManagerException_Error = new System.Windows.Forms.TextBox();
			this.TXT_ManagerException_Message = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel1);
			this.splitContainer1.Size = new System.Drawing.Size(372, 280);
			this.splitContainer1.SplitterDistance = 243;
			this.splitContainer1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(372, 243);
			this.panel2.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.BTN_ManagerException_GenerateReport);
			this.panel1.Controls.Add(this.BTN_ManagerException_Close);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(372, 33);
			this.panel1.TabIndex = 0;
			// 
			// BTN_ManagerException_GenerateReport
			// 
			this.BTN_ManagerException_GenerateReport.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.BTN_ManagerException_GenerateReport.Location = new System.Drawing.Point(-4, 3);
			this.BTN_ManagerException_GenerateReport.Name = "BTN_ManagerException_GenerateReport";
			this.BTN_ManagerException_GenerateReport.Size = new System.Drawing.Size(131, 23);
			this.BTN_ManagerException_GenerateReport.TabIndex = 8;
			this.BTN_ManagerException_GenerateReport.Text = "Generate Error Report";
			this.BTN_ManagerException_GenerateReport.UseVisualStyleBackColor = true;
			this.BTN_ManagerException_GenerateReport.Click += new System.EventHandler(this.BTN_ManagerException_GenerateReport_Click);
			// 
			// BTN_ManagerException_Close
			// 
			this.BTN_ManagerException_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BTN_ManagerException_Close.Location = new System.Drawing.Point(258, 3);
			this.BTN_ManagerException_Close.Name = "BTN_ManagerException_Close";
			this.BTN_ManagerException_Close.Size = new System.Drawing.Size(102, 23);
			this.BTN_ManagerException_Close.TabIndex = 7;
			this.BTN_ManagerException_Close.Text = "Close";
			this.BTN_ManagerException_Close.UseVisualStyleBackColor = true;
			this.BTN_ManagerException_Close.Click += new System.EventHandler(this.BTN_ManagerException_Close_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.TXT_ManagerException_Message);
			this.panel3.Controls.Add(this.TXT_ManagerException_Error);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(372, 243);
			this.panel3.TabIndex = 0;
			// 
			// TXT_ManagerException_Error
			// 
			this.TXT_ManagerException_Error.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TXT_ManagerException_Error.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TXT_ManagerException_Error.Location = new System.Drawing.Point(0, 53);
			this.TXT_ManagerException_Error.Multiline = true;
			this.TXT_ManagerException_Error.Name = "TXT_ManagerException_Error";
			this.TXT_ManagerException_Error.ReadOnly = true;
			this.TXT_ManagerException_Error.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TXT_ManagerException_Error.Size = new System.Drawing.Size(372, 190);
			this.TXT_ManagerException_Error.TabIndex = 5;
			// 
			// TXT_ManagerException_Message
			// 
			this.TXT_ManagerException_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TXT_ManagerException_Message.Location = new System.Drawing.Point(0, 0);
			this.TXT_ManagerException_Message.Multiline = true;
			this.TXT_ManagerException_Message.Name = "TXT_ManagerException_Message";
			this.TXT_ManagerException_Message.Size = new System.Drawing.Size(366, 47);
			this.TXT_ManagerException_Message.TabIndex = 6;
			// 
			// ManagerException
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 280);
			this.Controls.Add(this.splitContainer1);
			this.Name = "ManagerException";
			this.Text = "Manager Exception";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button BTN_ManagerException_GenerateReport;
		private System.Windows.Forms.Button BTN_ManagerException_Close;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox TXT_ManagerException_Message;
		private System.Windows.Forms.TextBox TXT_ManagerException_Error;
	}
}