namespace DESERVE.Manager
{
	partial class DESERVEManagerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DESERVEManagerForm));
			this.OLV_ServerInstances = new BrightIdeasSoftware.ObjectListView();
			this.SaveNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.BTN_StartServer = new System.Windows.Forms.Button();
			this.BTN_StopServer = new System.Windows.Forms.Button();
			this.BTN_Save = new System.Windows.Forms.Button();
			this.TXT_InfoBox = new System.Windows.Forms.TextBox();
			this.TXT_InstanceName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.BTN_TestConnect = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.OLV_ServerInstances)).BeginInit();
			this.SuspendLayout();
			// 
			// OLV_ServerInstances
			// 
			this.OLV_ServerInstances.AllColumns.Add(this.SaveNameColumn);
			this.OLV_ServerInstances.AllColumns.Add(this.olvColumn1);
			this.OLV_ServerInstances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SaveNameColumn,
            this.olvColumn1});
			this.OLV_ServerInstances.Location = new System.Drawing.Point(25, 325);
			this.OLV_ServerInstances.Name = "OLV_ServerInstances";
			this.OLV_ServerInstances.Size = new System.Drawing.Size(424, 104);
			this.OLV_ServerInstances.TabIndex = 0;
			this.OLV_ServerInstances.UseCompatibleStateImageBehavior = false;
			this.OLV_ServerInstances.View = System.Windows.Forms.View.Details;
			// 
			// SaveNameColumn
			// 
			this.SaveNameColumn.AspectName = "Name";
			this.SaveNameColumn.Text = "Name";
			this.SaveNameColumn.Width = 106;
			// 
			// olvColumn1
			// 
			this.olvColumn1.AspectName = "IsRunning";
			this.olvColumn1.Text = "Is Running";
			this.olvColumn1.Width = 125;
			// 
			// BTN_StartServer
			// 
			this.BTN_StartServer.Location = new System.Drawing.Point(25, 435);
			this.BTN_StartServer.Name = "BTN_StartServer";
			this.BTN_StartServer.Size = new System.Drawing.Size(75, 23);
			this.BTN_StartServer.TabIndex = 1;
			this.BTN_StartServer.Text = "Start Server";
			this.BTN_StartServer.UseVisualStyleBackColor = true;
			this.BTN_StartServer.Click += new System.EventHandler(this.BTN_StartServer_Click);
			// 
			// BTN_StopServer
			// 
			this.BTN_StopServer.Location = new System.Drawing.Point(12, 216);
			this.BTN_StopServer.Name = "BTN_StopServer";
			this.BTN_StopServer.Size = new System.Drawing.Size(75, 23);
			this.BTN_StopServer.TabIndex = 2;
			this.BTN_StopServer.Text = "Stop Server";
			this.BTN_StopServer.UseVisualStyleBackColor = true;
			this.BTN_StopServer.Click += new System.EventHandler(this.BTN_StopServer_Click);
			// 
			// BTN_Save
			// 
			this.BTN_Save.Location = new System.Drawing.Point(97, 216);
			this.BTN_Save.Name = "BTN_Save";
			this.BTN_Save.Size = new System.Drawing.Size(106, 23);
			this.BTN_Save.TabIndex = 3;
			this.BTN_Save.Text = "Save World";
			this.BTN_Save.UseVisualStyleBackColor = true;
			this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
			// 
			// TXT_InfoBox
			// 
			this.TXT_InfoBox.Location = new System.Drawing.Point(12, 64);
			this.TXT_InfoBox.Multiline = true;
			this.TXT_InfoBox.Name = "TXT_InfoBox";
			this.TXT_InfoBox.Size = new System.Drawing.Size(362, 130);
			this.TXT_InfoBox.TabIndex = 4;
			this.TXT_InfoBox.Text = resources.GetString("TXT_InfoBox.Text");
			// 
			// TXT_InstanceName
			// 
			this.TXT_InstanceName.Location = new System.Drawing.Point(97, 13);
			this.TXT_InstanceName.Name = "TXT_InstanceName";
			this.TXT_InstanceName.Size = new System.Drawing.Size(128, 20);
			this.TXT_InstanceName.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Instance Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Info";
			// 
			// BTN_TestConnect
			// 
			this.BTN_TestConnect.Location = new System.Drawing.Point(248, 13);
			this.BTN_TestConnect.Name = "BTN_TestConnect";
			this.BTN_TestConnect.Size = new System.Drawing.Size(126, 23);
			this.BTN_TestConnect.TabIndex = 8;
			this.BTN_TestConnect.Text = "Connect To Server";
			this.BTN_TestConnect.UseVisualStyleBackColor = true;
			this.BTN_TestConnect.Click += new System.EventHandler(this.BTN_TestConnect_Click);
			// 
			// DESERVEManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(392, 251);
			this.Controls.Add(this.BTN_TestConnect);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TXT_InstanceName);
			this.Controls.Add(this.TXT_InfoBox);
			this.Controls.Add(this.BTN_Save);
			this.Controls.Add(this.BTN_StopServer);
			this.Controls.Add(this.BTN_StartServer);
			this.Controls.Add(this.OLV_ServerInstances);
			this.Name = "DESERVEManagerForm";
			this.Text = "DESERVE Manager v1.0.0.3";
			((System.ComponentModel.ISupportInitialize)(this.OLV_ServerInstances)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private BrightIdeasSoftware.ObjectListView OLV_ServerInstances;
		private System.Windows.Forms.Button BTN_StartServer;
		private System.Windows.Forms.Button BTN_StopServer;
		private BrightIdeasSoftware.OLVColumn SaveNameColumn;
		private System.Windows.Forms.Button BTN_Save;
		private BrightIdeasSoftware.OLVColumn olvColumn1;
		private System.Windows.Forms.TextBox TXT_InfoBox;
		private System.Windows.Forms.TextBox TXT_InstanceName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BTN_TestConnect;
	}
}

