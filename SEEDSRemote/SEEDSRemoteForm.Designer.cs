﻿namespace SEEDSRemote
{
	partial class SEEDSRemoteForm
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
			this.OLV_ServerInstances = new BrightIdeasSoftware.ObjectListView();
			this.BTN_StartServer = new System.Windows.Forms.Button();
			this.BTN_StopServer = new System.Windows.Forms.Button();
			this.BTN_StopAllServers = new System.Windows.Forms.Button();
			this.SaveNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			((System.ComponentModel.ISupportInitialize)(this.OLV_ServerInstances)).BeginInit();
			this.SuspendLayout();
			// 
			// OLV_ServerInstances
			// 
			this.OLV_ServerInstances.AllColumns.Add(this.SaveNameColumn);
			this.OLV_ServerInstances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SaveNameColumn});
			this.OLV_ServerInstances.Location = new System.Drawing.Point(25, 12);
			this.OLV_ServerInstances.Name = "OLV_ServerInstances";
			this.OLV_ServerInstances.Size = new System.Drawing.Size(334, 104);
			this.OLV_ServerInstances.TabIndex = 0;
			this.OLV_ServerInstances.UseCompatibleStateImageBehavior = false;
			this.OLV_ServerInstances.View = System.Windows.Forms.View.Details;
			// 
			// BTN_StartServer
			// 
			this.BTN_StartServer.Location = new System.Drawing.Point(25, 134);
			this.BTN_StartServer.Name = "BTN_StartServer";
			this.BTN_StartServer.Size = new System.Drawing.Size(75, 23);
			this.BTN_StartServer.TabIndex = 1;
			this.BTN_StartServer.Text = "Start Server";
			this.BTN_StartServer.UseVisualStyleBackColor = true;
			this.BTN_StartServer.Click += new System.EventHandler(this.BTN_StartServer_Click);
			// 
			// BTN_StopServer
			// 
			this.BTN_StopServer.Location = new System.Drawing.Point(107, 134);
			this.BTN_StopServer.Name = "BTN_StopServer";
			this.BTN_StopServer.Size = new System.Drawing.Size(75, 23);
			this.BTN_StopServer.TabIndex = 2;
			this.BTN_StopServer.Text = "Stop Server";
			this.BTN_StopServer.UseVisualStyleBackColor = true;
			this.BTN_StopServer.Click += new System.EventHandler(this.BTN_StopServer_Click);
			// 
			// BTN_StopAllServers
			// 
			this.BTN_StopAllServers.Location = new System.Drawing.Point(253, 134);
			this.BTN_StopAllServers.Name = "BTN_StopAllServers";
			this.BTN_StopAllServers.Size = new System.Drawing.Size(106, 23);
			this.BTN_StopAllServers.TabIndex = 3;
			this.BTN_StopAllServers.Text = "Stop All Servers";
			this.BTN_StopAllServers.UseVisualStyleBackColor = true;
			this.BTN_StopAllServers.Click += new System.EventHandler(this.BTN_StopAllServers_Click);
			// 
			// SaveNameColumn
			// 
			this.SaveNameColumn.AspectName = "SaveFile";
			this.SaveNameColumn.Text = "Save Name";
			this.SaveNameColumn.Width = 268;
			// 
			// SEEDSRemoteForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(388, 172);
			this.Controls.Add(this.BTN_StopAllServers);
			this.Controls.Add(this.BTN_StopServer);
			this.Controls.Add(this.BTN_StartServer);
			this.Controls.Add(this.OLV_ServerInstances);
			this.Name = "SEEDSRemoteForm";
			this.Text = "SEEDS Remote";
			((System.ComponentModel.ISupportInitialize)(this.OLV_ServerInstances)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private BrightIdeasSoftware.ObjectListView OLV_ServerInstances;
		private System.Windows.Forms.Button BTN_StartServer;
		private System.Windows.Forms.Button BTN_StopServer;
		private System.Windows.Forms.Button BTN_StopAllServers;
		private BrightIdeasSoftware.OLVColumn SaveNameColumn;
	}
}

