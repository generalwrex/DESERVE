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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.m_statusBar = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.instancesPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.TAB_ServerControl = new System.Windows.Forms.TabControl();
			this.TAB_ServerControl_Page = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.OLV_ServerInstances = new BrightIdeasSoftware.ObjectListView();
			this.SaveNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.button1 = new System.Windows.Forms.Button();
			this.BTN_Save = new System.Windows.Forms.Button();
			this.BTN_StopServer = new System.Windows.Forms.Button();
			this.BTN_StartServer = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.splitContainer5 = new System.Windows.Forms.SplitContainer();
			this.PG_CommandLineArgs = new System.Windows.Forms.PropertyGrid();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.TAB_ManagerConfig_Page = new System.Windows.Forms.TabPage();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.TAB_Chat_Page = new System.Windows.Forms.TabPage();
			this.DedicatedServerPathDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.LBL_CurrentlyManaging = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.TAB_ServerControl.SuspendLayout();
			this.TAB_ServerControl_Page.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.OLV_ServerInstances)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
			this.splitContainer5.Panel1.SuspendLayout();
			this.splitContainer5.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.SuspendLayout();
			this.TAB_ManagerConfig_Page.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
			this.splitContainer4.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_statusBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 586);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// m_statusBar
			// 
			this.m_statusBar.Name = "m_statusBar";
			this.m_statusBar.Size = new System.Drawing.Size(39, 17);
			this.m_statusBar.Text = "Ready";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instancesPathToolStripMenuItem,
            this.loadConfigToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// instancesPathToolStripMenuItem
			// 
			this.instancesPathToolStripMenuItem.Name = "instancesPathToolStripMenuItem";
			this.instancesPathToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.instancesPathToolStripMenuItem.Text = "Save Config...";
			// 
			// loadConfigToolStripMenuItem
			// 
			this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
			this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.loadConfigToolStripMenuItem.Text = "Load Config...";
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPathsToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// setPathsToolStripMenuItem
			// 
			this.setPathsToolStripMenuItem.Name = "setPathsToolStripMenuItem";
			this.setPathsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.setPathsToolStripMenuItem.Text = "Set Paths";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.LBL_CurrentlyManaging);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.TAB_ServerControl);
			this.splitContainer1.Size = new System.Drawing.Size(1020, 562);
			this.splitContainer1.SplitterDistance = 35;
			this.splitContainer1.TabIndex = 2;
			// 
			// TAB_ServerControl
			// 
			this.TAB_ServerControl.Controls.Add(this.TAB_ServerControl_Page);
			this.TAB_ServerControl.Controls.Add(this.TAB_ManagerConfig_Page);
			this.TAB_ServerControl.Controls.Add(this.TAB_Chat_Page);
			this.TAB_ServerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TAB_ServerControl.Location = new System.Drawing.Point(0, 0);
			this.TAB_ServerControl.Name = "TAB_ServerControl";
			this.TAB_ServerControl.SelectedIndex = 0;
			this.TAB_ServerControl.Size = new System.Drawing.Size(1020, 523);
			this.TAB_ServerControl.TabIndex = 1;
			// 
			// TAB_ServerControl_Page
			// 
			this.TAB_ServerControl_Page.Controls.Add(this.tabControl1);
			this.TAB_ServerControl_Page.Location = new System.Drawing.Point(4, 22);
			this.TAB_ServerControl_Page.Name = "TAB_ServerControl_Page";
			this.TAB_ServerControl_Page.Padding = new System.Windows.Forms.Padding(3);
			this.TAB_ServerControl_Page.Size = new System.Drawing.Size(1012, 497);
			this.TAB_ServerControl_Page.TabIndex = 0;
			this.TAB_ServerControl_Page.Text = "Server Control";
			this.TAB_ServerControl_Page.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1006, 491);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.splitContainer2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(998, 465);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Control";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.OLV_ServerInstances);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.button1);
			this.splitContainer2.Panel2.Controls.Add(this.BTN_Save);
			this.splitContainer2.Panel2.Controls.Add(this.BTN_StopServer);
			this.splitContainer2.Panel2.Controls.Add(this.BTN_StartServer);
			this.splitContainer2.Size = new System.Drawing.Size(992, 459);
			this.splitContainer2.SplitterDistance = 250;
			this.splitContainer2.TabIndex = 1;
			// 
			// OLV_ServerInstances
			// 
			this.OLV_ServerInstances.AllColumns.Add(this.SaveNameColumn);
			this.OLV_ServerInstances.AllColumns.Add(this.olvColumn1);
			this.OLV_ServerInstances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SaveNameColumn,
            this.olvColumn1,
            this.olvColumn2});
			this.OLV_ServerInstances.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OLV_ServerInstances.Location = new System.Drawing.Point(0, 0);
			this.OLV_ServerInstances.MultiSelect = false;
			this.OLV_ServerInstances.Name = "OLV_ServerInstances";
			this.OLV_ServerInstances.ShowGroups = false;
			this.OLV_ServerInstances.Size = new System.Drawing.Size(992, 250);
			this.OLV_ServerInstances.TabIndex = 33;
			this.OLV_ServerInstances.UseCompatibleStateImageBehavior = false;
			this.OLV_ServerInstances.View = System.Windows.Forms.View.Details;
			this.OLV_ServerInstances.SelectedIndexChanged += new System.EventHandler(this.OLV_ServerInstances_SelectedIndexChanged);
			// 
			// SaveNameColumn
			// 
			this.SaveNameColumn.AspectName = "Name";
			this.SaveNameColumn.Text = "Name";
			this.SaveNameColumn.Width = 156;
			// 
			// olvColumn1
			// 
			this.olvColumn1.AspectName = "IsRunning";
			this.olvColumn1.Text = "Is Running";
			this.olvColumn1.Width = 125;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(330, 14);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 40;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// BTN_Save
			// 
			this.BTN_Save.Location = new System.Drawing.Point(180, 15);
			this.BTN_Save.Name = "BTN_Save";
			this.BTN_Save.Size = new System.Drawing.Size(106, 23);
			this.BTN_Save.TabIndex = 39;
			this.BTN_Save.Text = "Save World";
			this.BTN_Save.UseVisualStyleBackColor = true;
			this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
			// 
			// BTN_StopServer
			// 
			this.BTN_StopServer.Location = new System.Drawing.Point(99, 15);
			this.BTN_StopServer.Name = "BTN_StopServer";
			this.BTN_StopServer.Size = new System.Drawing.Size(75, 23);
			this.BTN_StopServer.TabIndex = 38;
			this.BTN_StopServer.Text = "Stop Server";
			this.BTN_StopServer.UseVisualStyleBackColor = true;
			this.BTN_StopServer.Click += new System.EventHandler(this.BTN_StopServer_Click);
			// 
			// BTN_StartServer
			// 
			this.BTN_StartServer.Location = new System.Drawing.Point(18, 15);
			this.BTN_StartServer.Name = "BTN_StartServer";
			this.BTN_StartServer.Size = new System.Drawing.Size(75, 23);
			this.BTN_StartServer.TabIndex = 37;
			this.BTN_StartServer.Text = "Start Server";
			this.BTN_StartServer.UseVisualStyleBackColor = true;
			this.BTN_StartServer.Click += new System.EventHandler(this.BTN_StartServer_Click);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.splitContainer5);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(998, 464);
			this.tabPage4.TabIndex = 2;
			this.tabPage4.Text = "Instance Configuration";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// splitContainer5
			// 
			this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer5.Location = new System.Drawing.Point(3, 3);
			this.splitContainer5.Name = "splitContainer5";
			this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer5.Panel1
			// 
			this.splitContainer5.Panel1.Controls.Add(this.PG_CommandLineArgs);
			this.splitContainer5.Size = new System.Drawing.Size(992, 458);
			this.splitContainer5.SplitterDistance = 218;
			this.splitContainer5.TabIndex = 0;
			// 
			// PG_CommandLineArgs
			// 
			this.PG_CommandLineArgs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PG_CommandLineArgs.Location = new System.Drawing.Point(0, 0);
			this.PG_CommandLineArgs.Name = "PG_CommandLineArgs";
			this.PG_CommandLineArgs.Size = new System.Drawing.Size(992, 218);
			this.PG_CommandLineArgs.TabIndex = 45;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.splitContainer3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(998, 464);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Dedicated Config";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(3, 3);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer3.Size = new System.Drawing.Size(992, 458);
			this.splitContainer3.SplitterDistance = 399;
			this.splitContainer3.TabIndex = 1;
			// 
			// TAB_ManagerConfig_Page
			// 
			this.TAB_ManagerConfig_Page.Controls.Add(this.splitContainer4);
			this.TAB_ManagerConfig_Page.Location = new System.Drawing.Point(4, 22);
			this.TAB_ManagerConfig_Page.Name = "TAB_ManagerConfig_Page";
			this.TAB_ManagerConfig_Page.Padding = new System.Windows.Forms.Padding(3);
			this.TAB_ManagerConfig_Page.Size = new System.Drawing.Size(1012, 496);
			this.TAB_ManagerConfig_Page.TabIndex = 1;
			this.TAB_ManagerConfig_Page.Text = "Manager Configuration";
			this.TAB_ManagerConfig_Page.UseVisualStyleBackColor = true;
			// 
			// splitContainer4
			// 
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new System.Drawing.Point(3, 3);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Size = new System.Drawing.Size(1006, 490);
			this.splitContainer4.SplitterDistance = 432;
			this.splitContainer4.TabIndex = 0;
			// 
			// TAB_Chat_Page
			// 
			this.TAB_Chat_Page.Location = new System.Drawing.Point(4, 22);
			this.TAB_Chat_Page.Name = "TAB_Chat_Page";
			this.TAB_Chat_Page.Padding = new System.Windows.Forms.Padding(3);
			this.TAB_Chat_Page.Size = new System.Drawing.Size(1012, 496);
			this.TAB_Chat_Page.TabIndex = 2;
			this.TAB_Chat_Page.Text = "Chat";
			this.TAB_Chat_Page.UseVisualStyleBackColor = true;
			// 
			// DedicatedServerPathDialog
			// 
			this.DedicatedServerPathDialog.ShowNewFolderButton = false;
			// 
			// LBL_CurrentlyManaging
			// 
			this.LBL_CurrentlyManaging.AutoSize = true;
			this.LBL_CurrentlyManaging.Location = new System.Drawing.Point(122, 11);
			this.LBL_CurrentlyManaging.Name = "LBL_CurrentlyManaging";
			this.LBL_CurrentlyManaging.Size = new System.Drawing.Size(155, 13);
			this.LBL_CurrentlyManaging.TabIndex = 1;
			this.LBL_CurrentlyManaging.Text = "Not Connected To Any Servers";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Currently Managing: ";
			// 
			// olvColumn2
			// 
			this.olvColumn2.AspectName = "ArgumentsString";
			this.olvColumn2.Text = "Command Line Args";
			this.olvColumn2.Width = 652;
			// 
			// DESERVEManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 608);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "DESERVEManagerForm";
			this.Text = "DESERVE Manager v1.0.0.3";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.TAB_ServerControl.ResumeLayout(false);
			this.TAB_ServerControl_Page.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.OLV_ServerInstances)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.splitContainer5.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
			this.splitContainer5.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.TAB_ManagerConfig_Page.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel m_statusBar;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem instancesPathToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setPathsToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl TAB_ServerControl;
		private System.Windows.Forms.TabPage TAB_ServerControl_Page;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private BrightIdeasSoftware.ObjectListView OLV_ServerInstances;
		private BrightIdeasSoftware.OLVColumn SaveNameColumn;
		private BrightIdeasSoftware.OLVColumn olvColumn1;
		private System.Windows.Forms.Button BTN_Save;
		private System.Windows.Forms.Button BTN_StopServer;
		private System.Windows.Forms.Button BTN_StartServer;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage TAB_ManagerConfig_Page;
		private System.Windows.Forms.SplitContainer splitContainer4;
		private System.Windows.Forms.SplitContainer splitContainer5;
		private System.Windows.Forms.PropertyGrid PG_CommandLineArgs;
		private System.Windows.Forms.FolderBrowserDialog DedicatedServerPathDialog;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabPage TAB_Chat_Page;
		private System.Windows.Forms.Label LBL_CurrentlyManaging;
		private System.Windows.Forms.Label label1;
		private BrightIdeasSoftware.OLVColumn olvColumn2;

	}
}

