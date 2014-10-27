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
			this.label1 = new System.Windows.Forms.Label();
			this.TAB_MainTabs = new System.Windows.Forms.TabControl();
			this.TAB_ServerControl_Page = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.OLV_ServerInstances = new BrightIdeasSoftware.ObjectListView();
			this.SaveNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.BTN_Save = new System.Windows.Forms.Button();
			this.BTN_StopServer = new System.Windows.Forms.Button();
			this.BTN_StartServer = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.splitContainer5 = new System.Windows.Forms.SplitContainer();
			this.PG_CommandLineArgs = new System.Windows.Forms.PropertyGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.BTN_InstanceConfiguration_Cancel = new System.Windows.Forms.Button();
			this.BTN_InstanceConfiguration_Save = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.TAB_ManagerConfig_Page = new System.Windows.Forms.TabPage();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.BTN_ManagerConfiguration_Browse = new System.Windows.Forms.Button();
			this.TXT_ManagerConfiguration_DESERVEPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TAB_Chat_Page = new System.Windows.Forms.TabPage();
			this.DIALOG_ManagerConfiguration_DESERVEPath = new System.Windows.Forms.FolderBrowserDialog();
			this.CMB_SelectedInstance = new System.Windows.Forms.ComboBox();
			this.splitContainer6 = new System.Windows.Forms.SplitContainer();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.TAB_MainTabs.SuspendLayout();
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
			this.splitContainer5.Panel2.SuspendLayout();
			this.splitContainer5.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.SuspendLayout();
			this.TAB_ManagerConfig_Page.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			this.TAB_Chat_Page.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
			this.splitContainer6.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.CMB_SelectedInstance);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.TAB_MainTabs);
			this.splitContainer1.Size = new System.Drawing.Size(1020, 562);
			this.splitContainer1.SplitterDistance = 35;
			this.splitContainer1.TabIndex = 2;
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
			// TAB_MainTabs
			// 
			this.TAB_MainTabs.Controls.Add(this.TAB_ServerControl_Page);
			this.TAB_MainTabs.Controls.Add(this.TAB_ManagerConfig_Page);
			this.TAB_MainTabs.Controls.Add(this.TAB_Chat_Page);
			this.TAB_MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TAB_MainTabs.Location = new System.Drawing.Point(0, 0);
			this.TAB_MainTabs.Name = "TAB_MainTabs";
			this.TAB_MainTabs.SelectedIndex = 0;
			this.TAB_MainTabs.Size = new System.Drawing.Size(1020, 523);
			this.TAB_MainTabs.TabIndex = 1;
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
			// olvColumn2
			// 
			this.olvColumn2.AspectName = "ArgumentsString";
			this.olvColumn2.Text = "Command Line Args";
			this.olvColumn2.Width = 652;
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
			this.tabPage4.Size = new System.Drawing.Size(998, 465);
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
			// 
			// splitContainer5.Panel2
			// 
			this.splitContainer5.Panel2.Controls.Add(this.panel1);
			this.splitContainer5.Size = new System.Drawing.Size(992, 459);
			this.splitContainer5.SplitterDistance = 423;
			this.splitContainer5.TabIndex = 0;
			// 
			// PG_CommandLineArgs
			// 
			this.PG_CommandLineArgs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PG_CommandLineArgs.Location = new System.Drawing.Point(0, 0);
			this.PG_CommandLineArgs.Name = "PG_CommandLineArgs";
			this.PG_CommandLineArgs.Size = new System.Drawing.Size(992, 423);
			this.PG_CommandLineArgs.TabIndex = 45;
			this.PG_CommandLineArgs.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PG_CommandLineArgs_PropertyValueChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.BTN_InstanceConfiguration_Cancel);
			this.panel1.Controls.Add(this.BTN_InstanceConfiguration_Save);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(992, 32);
			this.panel1.TabIndex = 0;
			// 
			// BTN_InstanceConfiguration_Cancel
			// 
			this.BTN_InstanceConfiguration_Cancel.Location = new System.Drawing.Point(751, 3);
			this.BTN_InstanceConfiguration_Cancel.Name = "BTN_InstanceConfiguration_Cancel";
			this.BTN_InstanceConfiguration_Cancel.Size = new System.Drawing.Size(99, 23);
			this.BTN_InstanceConfiguration_Cancel.TabIndex = 1;
			this.BTN_InstanceConfiguration_Cancel.Text = "Cancel Changes";
			this.BTN_InstanceConfiguration_Cancel.UseVisualStyleBackColor = true;
			this.BTN_InstanceConfiguration_Cancel.Click += new System.EventHandler(this.BTN_InstanceConfiguration_Cancel_Click);
			// 
			// BTN_InstanceConfiguration_Save
			// 
			this.BTN_InstanceConfiguration_Save.Location = new System.Drawing.Point(867, 3);
			this.BTN_InstanceConfiguration_Save.Name = "BTN_InstanceConfiguration_Save";
			this.BTN_InstanceConfiguration_Save.Size = new System.Drawing.Size(112, 23);
			this.BTN_InstanceConfiguration_Save.TabIndex = 0;
			this.BTN_InstanceConfiguration_Save.Text = "Save Changes";
			this.BTN_InstanceConfiguration_Save.UseVisualStyleBackColor = true;
			this.BTN_InstanceConfiguration_Save.Click += new System.EventHandler(this.BTN_InstanceConfiguration_Save_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.splitContainer3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(998, 465);
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
			this.splitContainer3.Size = new System.Drawing.Size(992, 459);
			this.splitContainer3.SplitterDistance = 399;
			this.splitContainer3.TabIndex = 1;
			// 
			// TAB_ManagerConfig_Page
			// 
			this.TAB_ManagerConfig_Page.Controls.Add(this.splitContainer4);
			this.TAB_ManagerConfig_Page.Location = new System.Drawing.Point(4, 22);
			this.TAB_ManagerConfig_Page.Name = "TAB_ManagerConfig_Page";
			this.TAB_ManagerConfig_Page.Padding = new System.Windows.Forms.Padding(3);
			this.TAB_ManagerConfig_Page.Size = new System.Drawing.Size(1012, 497);
			this.TAB_ManagerConfig_Page.TabIndex = 1;
			this.TAB_ManagerConfig_Page.Text = "Manager Configuration";
			this.TAB_ManagerConfig_Page.UseVisualStyleBackColor = true;
			// 
			// splitContainer4
			// 
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new System.Drawing.Point(3, 3);
			this.splitContainer4.Name = "splitContainer4";
			// 
			// splitContainer4.Panel1
			// 
			this.splitContainer4.Panel1.Controls.Add(this.BTN_ManagerConfiguration_Browse);
			this.splitContainer4.Panel1.Controls.Add(this.TXT_ManagerConfiguration_DESERVEPath);
			this.splitContainer4.Panel1.Controls.Add(this.label2);
			this.splitContainer4.Size = new System.Drawing.Size(1006, 491);
			this.splitContainer4.SplitterDistance = 433;
			this.splitContainer4.TabIndex = 0;
			// 
			// BTN_ManagerConfiguration_Browse
			// 
			this.BTN_ManagerConfiguration_Browse.Location = new System.Drawing.Point(268, 37);
			this.BTN_ManagerConfiguration_Browse.Name = "BTN_ManagerConfiguration_Browse";
			this.BTN_ManagerConfiguration_Browse.Size = new System.Drawing.Size(75, 20);
			this.BTN_ManagerConfiguration_Browse.TabIndex = 2;
			this.BTN_ManagerConfiguration_Browse.Text = "Browse";
			this.BTN_ManagerConfiguration_Browse.UseVisualStyleBackColor = true;
			this.BTN_ManagerConfiguration_Browse.Click += new System.EventHandler(this.BTN_ManagerConfiguration_Browse_Click);
			// 
			// TXT_ManagerConfiguration_DESERVEPath
			// 
			this.TXT_ManagerConfiguration_DESERVEPath.Location = new System.Drawing.Point(8, 37);
			this.TXT_ManagerConfiguration_DESERVEPath.Name = "TXT_ManagerConfiguration_DESERVEPath";
			this.TXT_ManagerConfiguration_DESERVEPath.Size = new System.Drawing.Size(254, 20);
			this.TXT_ManagerConfiguration_DESERVEPath.TabIndex = 1;
			this.TXT_ManagerConfiguration_DESERVEPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_ManagerConfiguration_DESERVEPath_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "DESERVE Path:";
			// 
			// TAB_Chat_Page
			// 
			this.TAB_Chat_Page.Controls.Add(this.splitContainer6);
			this.TAB_Chat_Page.Location = new System.Drawing.Point(4, 22);
			this.TAB_Chat_Page.Name = "TAB_Chat_Page";
			this.TAB_Chat_Page.Padding = new System.Windows.Forms.Padding(3);
			this.TAB_Chat_Page.Size = new System.Drawing.Size(1012, 497);
			this.TAB_Chat_Page.TabIndex = 2;
			this.TAB_Chat_Page.Text = "Chat";
			this.TAB_Chat_Page.UseVisualStyleBackColor = true;
			// 
			// CMB_SelectedInstance
			// 
			this.CMB_SelectedInstance.FormattingEnabled = true;
			this.CMB_SelectedInstance.Location = new System.Drawing.Point(122, 8);
			this.CMB_SelectedInstance.Name = "CMB_SelectedInstance";
			this.CMB_SelectedInstance.Size = new System.Drawing.Size(160, 21);
			this.CMB_SelectedInstance.TabIndex = 1;
			this.CMB_SelectedInstance.SelectedIndexChanged += new System.EventHandler(this.CMB_SelectedInstance_SelectedIndexChanged);
			// 
			// splitContainer6
			// 
			this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer6.Location = new System.Drawing.Point(3, 3);
			this.splitContainer6.Name = "splitContainer6";
			this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer6.Size = new System.Drawing.Size(1006, 491);
			this.splitContainer6.SplitterDistance = 248;
			this.splitContainer6.TabIndex = 0;
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
			this.TAB_MainTabs.ResumeLayout(false);
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
			this.splitContainer5.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
			this.splitContainer5.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.TAB_ManagerConfig_Page.ResumeLayout(false);
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.TAB_Chat_Page.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
			this.splitContainer6.ResumeLayout(false);
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
		private System.Windows.Forms.TabControl TAB_MainTabs;
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
		private System.Windows.Forms.TabPage TAB_Chat_Page;
		private System.Windows.Forms.Label label1;
		private BrightIdeasSoftware.OLVColumn olvColumn2;
		private System.Windows.Forms.TextBox TXT_ManagerConfiguration_DESERVEPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FolderBrowserDialog DIALOG_ManagerConfiguration_DESERVEPath;
		private System.Windows.Forms.Button BTN_ManagerConfiguration_Browse;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button BTN_InstanceConfiguration_Cancel;
		private System.Windows.Forms.Button BTN_InstanceConfiguration_Save;
		private System.Windows.Forms.ComboBox CMB_SelectedInstance;
		private System.Windows.Forms.SplitContainer splitContainer6;

	}
}

