namespace DSM.GUI.Forms {
	partial class WndMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.menu = new System.Windows.Forms.MainMenu(this.components);
			this.menuFileItem = new System.Windows.Forms.MenuItem();
			this.menuFileItemRestart = new System.Windows.Forms.MenuItem();
			this.menuFileItemExit = new System.Windows.Forms.MenuItem();
			this.menuOptionsItem = new System.Windows.Forms.MenuItem();
			this.menuOptionsItemVariant = new System.Windows.Forms.MenuItem();
			this.menuOptionsItemSeparator = new System.Windows.Forms.MenuItem();
			this.menuOptionsItemSettings = new System.Windows.Forms.MenuItem();
			this.menuHelpItem = new System.Windows.Forms.MenuItem();
			this.menuHelpItemAbout = new System.Windows.Forms.MenuItem();
			this.tvModules = new System.Windows.Forms.TreeView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pModule = new System.Windows.Forms.Panel();
			this.tctModule = new System.Windows.Forms.TabControl();
			this.tpModuleInfo = new System.Windows.Forms.TabPage();
			this.gbModuleInfoDetails = new System.Windows.Forms.GroupBox();
			this.pbModuleInfoIcon = new System.Windows.Forms.PictureBox();
			this.lblModuleInfoDetailsVersionValue = new System.Windows.Forms.Label();
			this.lblModuleInfoDetailsVersion = new System.Windows.Forms.Label();
			this.lblModuleInfoDetailsDescriptionValue = new System.Windows.Forms.Label();
			this.lblModuleInfoDetailsDeveloperValue = new System.Windows.Forms.Label();
			this.lblModuleInfoDetailsSlugUpdateValue = new System.Windows.Forms.Label();
			this.lblModuleInfoDetailsSlugFilesystemValue = new System.Windows.Forms.Label();
			this.lblModuleInfoDetailsSlugUpdate = new System.Windows.Forms.Label();
			this.lblModuleInfoDetailsSlugFilesystem = new System.Windows.Forms.Label();
			this.lblModuleInformationDetailsDeveloper = new System.Windows.Forms.Label();
			this.lblModuleInfoDetailsNameValue = new System.Windows.Forms.Label();
			this.lblModuleInfoDetailsName = new System.Windows.Forms.Label();
			this.gbModuleInfoInstallation = new System.Windows.Forms.GroupBox();
			this.lblModuleInfoInstallationPathValue = new System.Windows.Forms.LinkLabel();
			this.lblModuleInfoInstallationPath = new System.Windows.Forms.Label();
			this.tpModuleLiveries = new System.Windows.Forms.TabPage();
			this.tpModuleCountermeasures = new System.Windows.Forms.TabPage();
			this.tcModule = new System.Windows.Forms.TabControl();
			this.lblNoModuleSelected = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.pModule.SuspendLayout();
			this.tctModule.SuspendLayout();
			this.tpModuleInfo.SuspendLayout();
			this.gbModuleInfoDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbModuleInfoIcon)).BeginInit();
			this.gbModuleInfoInstallation.SuspendLayout();
			this.SuspendLayout();
			// 
			// menu
			// 
			this.menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileItem,
            this.menuOptionsItem,
            this.menuHelpItem});
			// 
			// menuFileItem
			// 
			this.menuFileItem.Index = 0;
			this.menuFileItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileItemRestart,
            this.menuFileItemExit});
			this.menuFileItem.Text = "&File";
			// 
			// menuFileItemRestart
			// 
			this.menuFileItemRestart.Index = 0;
			this.menuFileItemRestart.Text = "&Restart";
			this.menuFileItemRestart.Click += new System.EventHandler(this.OnMenuItem_Restart);
			// 
			// menuFileItemExit
			// 
			this.menuFileItemExit.Index = 1;
			this.menuFileItemExit.Text = "&Exit";
			this.menuFileItemExit.Click += new System.EventHandler(this.OnMenuItem_Exit);
			// 
			// menuOptionsItem
			// 
			this.menuOptionsItem.Index = 1;
			this.menuOptionsItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOptionsItemVariant,
            this.menuOptionsItemSeparator,
            this.menuOptionsItemSettings});
			this.menuOptionsItem.Text = "&Options";
			// 
			// menuOptionsItemVariant
			// 
			this.menuOptionsItemVariant.Index = 0;
			this.menuOptionsItemVariant.Text = "&Variant";
			// 
			// menuOptionsItemSeparator
			// 
			this.menuOptionsItemSeparator.Index = 1;
			this.menuOptionsItemSeparator.Text = "-";
			// 
			// menuOptionsItemSettings
			// 
			this.menuOptionsItemSettings.Index = 2;
			this.menuOptionsItemSettings.Text = "&Settings";
			this.menuOptionsItemSettings.Click += new System.EventHandler(this.OnMenuItem_Settings);
			// 
			// menuHelpItem
			// 
			this.menuHelpItem.Index = 2;
			this.menuHelpItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpItemAbout});
			this.menuHelpItem.Text = "&Help";
			// 
			// menuHelpItemAbout
			// 
			this.menuHelpItemAbout.Index = 0;
			this.menuHelpItemAbout.Text = "&About";
			this.menuHelpItemAbout.Click += new System.EventHandler(this.OnMenuItem_About);
			// 
			// tvModules
			// 
			this.tvModules.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvModules.FullRowSelect = true;
			this.tvModules.Location = new System.Drawing.Point(0, 0);
			this.tvModules.Name = "tvModules";
			this.tvModules.PathSeparator = "/";
			this.tvModules.ShowLines = false;
			this.tvModules.Size = new System.Drawing.Size(249, 540);
			this.tvModules.TabIndex = 3;
			this.tvModules.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeView_AfterSelect);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvModules);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pModule);
			this.splitContainer1.Panel2.Controls.Add(this.lblNoModuleSelected);
			this.splitContainer1.Size = new System.Drawing.Size(944, 540);
			this.splitContainer1.SplitterDistance = 249;
			this.splitContainer1.TabIndex = 4;
			// 
			// pModule
			// 
			this.pModule.Controls.Add(this.tctModule);
			this.pModule.Controls.Add(this.tcModule);
			this.pModule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pModule.Location = new System.Drawing.Point(0, 0);
			this.pModule.Name = "pModule";
			this.pModule.Size = new System.Drawing.Size(691, 540);
			this.pModule.TabIndex = 1;
			// 
			// tctModule
			// 
			this.tctModule.Controls.Add(this.tpModuleInfo);
			this.tctModule.Controls.Add(this.tpModuleLiveries);
			this.tctModule.Controls.Add(this.tpModuleCountermeasures);
			this.tctModule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tctModule.Location = new System.Drawing.Point(0, 0);
			this.tctModule.Name = "tctModule";
			this.tctModule.SelectedIndex = 0;
			this.tctModule.Size = new System.Drawing.Size(691, 540);
			this.tctModule.TabIndex = 0;
			this.tctModule.Visible = false;
			// 
			// tpModuleInfo
			// 
			this.tpModuleInfo.Controls.Add(this.gbModuleInfoDetails);
			this.tpModuleInfo.Controls.Add(this.gbModuleInfoInstallation);
			this.tpModuleInfo.Location = new System.Drawing.Point(4, 22);
			this.tpModuleInfo.Name = "tpModuleInfo";
			this.tpModuleInfo.Size = new System.Drawing.Size(683, 514);
			this.tpModuleInfo.TabIndex = 0;
			this.tpModuleInfo.Text = "Information";
			this.tpModuleInfo.UseVisualStyleBackColor = true;
			// 
			// gbModuleInfoDetails
			// 
			this.gbModuleInfoDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbModuleInfoDetails.Controls.Add(this.pbModuleInfoIcon);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsVersionValue);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsVersion);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsDescriptionValue);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsDeveloperValue);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsSlugUpdateValue);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsSlugFilesystemValue);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsSlugUpdate);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsSlugFilesystem);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInformationDetailsDeveloper);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsNameValue);
			this.gbModuleInfoDetails.Controls.Add(this.lblModuleInfoDetailsName);
			this.gbModuleInfoDetails.Location = new System.Drawing.Point(6, 46);
			this.gbModuleInfoDetails.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.gbModuleInfoDetails.Name = "gbModuleInfoDetails";
			this.gbModuleInfoDetails.Size = new System.Drawing.Size(669, 460);
			this.gbModuleInfoDetails.TabIndex = 1;
			this.gbModuleInfoDetails.TabStop = false;
			this.gbModuleInfoDetails.Text = "Details";
			// 
			// pbModuleInfoIcon
			// 
			this.pbModuleInfoIcon.Location = new System.Drawing.Point(6, 16);
			this.pbModuleInfoIcon.Name = "pbModuleInfoIcon";
			this.pbModuleInfoIcon.Size = new System.Drawing.Size(86, 86);
			this.pbModuleInfoIcon.TabIndex = 12;
			this.pbModuleInfoIcon.TabStop = false;
			// 
			// lblModuleInfoDetailsVersionValue
			// 
			this.lblModuleInfoDetailsVersionValue.AutoSize = true;
			this.lblModuleInfoDetailsVersionValue.Location = new System.Drawing.Point(190, 40);
			this.lblModuleInfoDetailsVersionValue.Name = "lblModuleInfoDetailsVersionValue";
			this.lblModuleInfoDetailsVersionValue.Size = new System.Drawing.Size(55, 13);
			this.lblModuleInfoDetailsVersionValue.TabIndex = 11;
			this.lblModuleInfoDetailsVersionValue.Text = "VERSION";
			// 
			// lblModuleInfoDetailsVersion
			// 
			this.lblModuleInfoDetailsVersion.AutoSize = true;
			this.lblModuleInfoDetailsVersion.Location = new System.Drawing.Point(98, 40);
			this.lblModuleInfoDetailsVersion.Name = "lblModuleInfoDetailsVersion";
			this.lblModuleInfoDetailsVersion.Size = new System.Drawing.Size(45, 13);
			this.lblModuleInfoDetailsVersion.TabIndex = 10;
			this.lblModuleInfoDetailsVersion.Text = "Version:";
			// 
			// lblModuleInfoDetailsDescriptionValue
			// 
			this.lblModuleInfoDetailsDescriptionValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblModuleInfoDetailsDescriptionValue.AutoEllipsis = true;
			this.lblModuleInfoDetailsDescriptionValue.Location = new System.Drawing.Point(9, 108);
			this.lblModuleInfoDetailsDescriptionValue.Margin = new System.Windows.Forms.Padding(6);
			this.lblModuleInfoDetailsDescriptionValue.Name = "lblModuleInfoDetailsDescriptionValue";
			this.lblModuleInfoDetailsDescriptionValue.Size = new System.Drawing.Size(651, 343);
			this.lblModuleInfoDetailsDescriptionValue.TabIndex = 9;
			this.lblModuleInfoDetailsDescriptionValue.Text = "DESCRIPTION";
			// 
			// lblModuleInfoDetailsDeveloperValue
			// 
			this.lblModuleInfoDetailsDeveloperValue.AutoSize = true;
			this.lblModuleInfoDetailsDeveloperValue.Location = new System.Drawing.Point(190, 53);
			this.lblModuleInfoDetailsDeveloperValue.Name = "lblModuleInfoDetailsDeveloperValue";
			this.lblModuleInfoDetailsDeveloperValue.Size = new System.Drawing.Size(72, 13);
			this.lblModuleInfoDetailsDeveloperValue.TabIndex = 7;
			this.lblModuleInfoDetailsDeveloperValue.Text = "DEVELOPER";
			// 
			// lblModuleInfoDetailsSlugUpdateValue
			// 
			this.lblModuleInfoDetailsSlugUpdateValue.AutoSize = true;
			this.lblModuleInfoDetailsSlugUpdateValue.Location = new System.Drawing.Point(190, 66);
			this.lblModuleInfoDetailsSlugUpdateValue.Name = "lblModuleInfoDetailsSlugUpdateValue";
			this.lblModuleInfoDetailsSlugUpdateValue.Size = new System.Drawing.Size(86, 13);
			this.lblModuleInfoDetailsSlugUpdateValue.TabIndex = 6;
			this.lblModuleInfoDetailsSlugUpdateValue.Text = "SLUG_UPDATE";
			// 
			// lblModuleInfoDetailsSlugFilesystemValue
			// 
			this.lblModuleInfoDetailsSlugFilesystemValue.AutoSize = true;
			this.lblModuleInfoDetailsSlugFilesystemValue.Location = new System.Drawing.Point(190, 79);
			this.lblModuleInfoDetailsSlugFilesystemValue.Name = "lblModuleInfoDetailsSlugFilesystemValue";
			this.lblModuleInfoDetailsSlugFilesystemValue.Size = new System.Drawing.Size(108, 13);
			this.lblModuleInfoDetailsSlugFilesystemValue.TabIndex = 5;
			this.lblModuleInfoDetailsSlugFilesystemValue.Text = "SLUG_FILESYSTEM";
			// 
			// lblModuleInfoDetailsSlugUpdate
			// 
			this.lblModuleInfoDetailsSlugUpdate.AutoSize = true;
			this.lblModuleInfoDetailsSlugUpdate.Location = new System.Drawing.Point(98, 66);
			this.lblModuleInfoDetailsSlugUpdate.Name = "lblModuleInfoDetailsSlugUpdate";
			this.lblModuleInfoDetailsSlugUpdate.Size = new System.Drawing.Size(67, 13);
			this.lblModuleInfoDetailsSlugUpdate.TabIndex = 4;
			this.lblModuleInfoDetailsSlugUpdate.Text = "Update slug:";
			// 
			// lblModuleInfoDetailsSlugFilesystem
			// 
			this.lblModuleInfoDetailsSlugFilesystem.AutoSize = true;
			this.lblModuleInfoDetailsSlugFilesystem.Location = new System.Drawing.Point(98, 79);
			this.lblModuleInfoDetailsSlugFilesystem.Name = "lblModuleInfoDetailsSlugFilesystem";
			this.lblModuleInfoDetailsSlugFilesystem.Size = new System.Drawing.Size(91, 13);
			this.lblModuleInfoDetailsSlugFilesystem.TabIndex = 3;
			this.lblModuleInfoDetailsSlugFilesystem.Text = "Filesystem slug(s):";
			// 
			// lblModuleInformationDetailsDeveloper
			// 
			this.lblModuleInformationDetailsDeveloper.AutoSize = true;
			this.lblModuleInformationDetailsDeveloper.Location = new System.Drawing.Point(98, 53);
			this.lblModuleInformationDetailsDeveloper.Name = "lblModuleInformationDetailsDeveloper";
			this.lblModuleInformationDetailsDeveloper.Size = new System.Drawing.Size(59, 13);
			this.lblModuleInformationDetailsDeveloper.TabIndex = 2;
			this.lblModuleInformationDetailsDeveloper.Text = "Developer:";
			// 
			// lblModuleInfoDetailsNameValue
			// 
			this.lblModuleInfoDetailsNameValue.AutoSize = true;
			this.lblModuleInfoDetailsNameValue.Location = new System.Drawing.Point(190, 27);
			this.lblModuleInfoDetailsNameValue.Name = "lblModuleInfoDetailsNameValue";
			this.lblModuleInfoDetailsNameValue.Size = new System.Drawing.Size(38, 13);
			this.lblModuleInfoDetailsNameValue.TabIndex = 1;
			this.lblModuleInfoDetailsNameValue.Text = "NAME";
			// 
			// lblModuleInfoDetailsName
			// 
			this.lblModuleInfoDetailsName.AutoSize = true;
			this.lblModuleInfoDetailsName.Location = new System.Drawing.Point(98, 27);
			this.lblModuleInfoDetailsName.Name = "lblModuleInfoDetailsName";
			this.lblModuleInfoDetailsName.Size = new System.Drawing.Size(38, 13);
			this.lblModuleInfoDetailsName.TabIndex = 0;
			this.lblModuleInfoDetailsName.Text = "Name:";
			// 
			// gbModuleInfoInstallation
			// 
			this.gbModuleInfoInstallation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbModuleInfoInstallation.Controls.Add(this.lblModuleInfoInstallationPathValue);
			this.gbModuleInfoInstallation.Controls.Add(this.lblModuleInfoInstallationPath);
			this.gbModuleInfoInstallation.Location = new System.Drawing.Point(6, 3);
			this.gbModuleInfoInstallation.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.gbModuleInfoInstallation.Name = "gbModuleInfoInstallation";
			this.gbModuleInfoInstallation.Size = new System.Drawing.Size(669, 37);
			this.gbModuleInfoInstallation.TabIndex = 0;
			this.gbModuleInfoInstallation.TabStop = false;
			this.gbModuleInfoInstallation.Text = "Installation";
			// 
			// lblModuleInfoInstallationPathValue
			// 
			this.lblModuleInfoInstallationPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblModuleInfoInstallationPathValue.AutoEllipsis = true;
			this.lblModuleInfoInstallationPathValue.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblModuleInfoInstallationPathValue.Location = new System.Drawing.Point(44, 16);
			this.lblModuleInfoInstallationPathValue.Name = "lblModuleInfoInstallationPathValue";
			this.lblModuleInfoInstallationPathValue.Size = new System.Drawing.Size(619, 13);
			this.lblModuleInfoInstallationPathValue.TabIndex = 1;
			this.lblModuleInfoInstallationPathValue.TabStop = true;
			this.lblModuleInfoInstallationPathValue.Text = "PATH";
			this.lblModuleInfoInstallationPathValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLinkClicked_OpenFolder);
			// 
			// lblModuleInfoInstallationPath
			// 
			this.lblModuleInfoInstallationPath.AutoSize = true;
			this.lblModuleInfoInstallationPath.Location = new System.Drawing.Point(6, 16);
			this.lblModuleInfoInstallationPath.Name = "lblModuleInfoInstallationPath";
			this.lblModuleInfoInstallationPath.Size = new System.Drawing.Size(32, 13);
			this.lblModuleInfoInstallationPath.TabIndex = 0;
			this.lblModuleInfoInstallationPath.Text = "Path:";
			// 
			// tpModuleLiveries
			// 
			this.tpModuleLiveries.Location = new System.Drawing.Point(4, 22);
			this.tpModuleLiveries.Name = "tpModuleLiveries";
			this.tpModuleLiveries.Size = new System.Drawing.Size(683, 514);
			this.tpModuleLiveries.TabIndex = 1;
			this.tpModuleLiveries.Tag = "Aircraft";
			this.tpModuleLiveries.Text = "Liveries";
			this.tpModuleLiveries.UseVisualStyleBackColor = true;
			// 
			// tpModuleCountermeasures
			// 
			this.tpModuleCountermeasures.Location = new System.Drawing.Point(4, 22);
			this.tpModuleCountermeasures.Name = "tpModuleCountermeasures";
			this.tpModuleCountermeasures.Size = new System.Drawing.Size(683, 514);
			this.tpModuleCountermeasures.TabIndex = 2;
			this.tpModuleCountermeasures.Tag = "Aircraft";
			this.tpModuleCountermeasures.Text = "Countermeasures";
			this.tpModuleCountermeasures.UseVisualStyleBackColor = true;
			// 
			// tcModule
			// 
			this.tcModule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcModule.Location = new System.Drawing.Point(0, 0);
			this.tcModule.Name = "tcModule";
			this.tcModule.SelectedIndex = 0;
			this.tcModule.Size = new System.Drawing.Size(691, 540);
			this.tcModule.TabIndex = 1;
			// 
			// lblNoModuleSelected
			// 
			this.lblNoModuleSelected.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblNoModuleSelected.Location = new System.Drawing.Point(0, 0);
			this.lblNoModuleSelected.Name = "lblNoModuleSelected";
			this.lblNoModuleSelected.Size = new System.Drawing.Size(691, 540);
			this.lblNoModuleSelected.TabIndex = 0;
			this.lblNoModuleSelected.Text = "Please select a module.";
			this.lblNoModuleSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WndMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(944, 540);
			this.Controls.Add(this.splitContainer1);
			this.Menu = this.menu;
			this.Name = "WndMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DCS State Manager";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.pModule.ResumeLayout(false);
			this.tctModule.ResumeLayout(false);
			this.tpModuleInfo.ResumeLayout(false);
			this.gbModuleInfoDetails.ResumeLayout(false);
			this.gbModuleInfoDetails.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbModuleInfoIcon)).EndInit();
			this.gbModuleInfoInstallation.ResumeLayout(false);
			this.gbModuleInfoInstallation.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MainMenu menu;
		private System.Windows.Forms.MenuItem menuFileItem;
		private System.Windows.Forms.MenuItem menuOptionsItemSettings;
		private System.Windows.Forms.MenuItem menuOptionsItemSeparator;
		private System.Windows.Forms.MenuItem menuFileItemExit;
		private System.Windows.Forms.MenuItem menuHelpItem;
		private System.Windows.Forms.MenuItem menuHelpItemAbout;
		private System.Windows.Forms.MenuItem menuFileItemRestart;
		private System.Windows.Forms.MenuItem menuOptionsItem;
		private System.Windows.Forms.MenuItem menuOptionsItemVariant;
		private System.Windows.Forms.TreeView tvModules;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel pModule;
		private System.Windows.Forms.TabControl tctModule;
		private System.Windows.Forms.TabPage tpModuleInfo;
		private System.Windows.Forms.TabPage tpModuleLiveries;
		private System.Windows.Forms.TabPage tpModuleCountermeasures;
		private System.Windows.Forms.Label lblNoModuleSelected;
		private System.Windows.Forms.TabControl tcModule;
		private System.Windows.Forms.GroupBox gbModuleInfoDetails;
		private System.Windows.Forms.Label lblModuleInfoDetailsNameValue;
		private System.Windows.Forms.Label lblModuleInfoDetailsName;
		private System.Windows.Forms.GroupBox gbModuleInfoInstallation;
		private System.Windows.Forms.Label lblModuleInfoDetailsDeveloperValue;
		private System.Windows.Forms.Label lblModuleInfoDetailsSlugUpdateValue;
		private System.Windows.Forms.Label lblModuleInfoDetailsSlugFilesystemValue;
		private System.Windows.Forms.Label lblModuleInfoDetailsSlugUpdate;
		private System.Windows.Forms.Label lblModuleInfoDetailsSlugFilesystem;
		private System.Windows.Forms.Label lblModuleInformationDetailsDeveloper;
		private System.Windows.Forms.Label lblModuleInfoDetailsDescriptionValue;
		private System.Windows.Forms.Label lblModuleInfoDetailsVersionValue;
		private System.Windows.Forms.Label lblModuleInfoDetailsVersion;
		private System.Windows.Forms.LinkLabel lblModuleInfoInstallationPathValue;
		private System.Windows.Forms.Label lblModuleInfoInstallationPath;
		private System.Windows.Forms.PictureBox pbModuleInfoIcon;
	}
}
