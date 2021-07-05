namespace DSM.GUI.Forms {
	partial class WndSettings {
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
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.tpAppearance = new System.Windows.Forms.TabPage();
			this.tpInstallation = new System.Windows.Forms.TabPage();
			this.gbOverride = new System.Windows.Forms.GroupBox();
			this.panelOverride = new System.Windows.Forms.Panel();
			this.cbOverrideFallback = new System.Windows.Forms.CheckBox();
			this.btnOverridePathBrowse = new System.Windows.Forms.Button();
			this.tbOverridePathValue = new System.Windows.Forms.TextBox();
			this.lblOverridePath = new System.Windows.Forms.Label();
			this.cbOverride = new System.Windows.Forms.CheckBox();
			this.gbDetected = new System.Windows.Forms.GroupBox();
			this.lblDetectedTypeValue = new System.Windows.Forms.LinkLabel();
			this.lblDetectedType = new System.Windows.Forms.Label();
			this.lblDetectedPath = new System.Windows.Forms.Label();
			this.lblDetectedPathValue = new System.Windows.Forms.LinkLabel();
			this.tcMain.SuspendLayout();
			this.tpInstallation.SuspendLayout();
			this.gbOverride.SuspendLayout();
			this.panelOverride.SuspendLayout();
			this.gbDetected.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcMain
			// 
			this.tcMain.Controls.Add(this.tpGeneral);
			this.tcMain.Controls.Add(this.tpAppearance);
			this.tcMain.Controls.Add(this.tpInstallation);
			this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcMain.Location = new System.Drawing.Point(0, 0);
			this.tcMain.Name = "tcMain";
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(528, 294);
			this.tcMain.TabIndex = 0;
			this.tcMain.SelectedIndexChanged += new System.EventHandler(this.OnTabControl_IndexChanged);
			// 
			// tpGeneral
			// 
			this.tpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Size = new System.Drawing.Size(520, 268);
			this.tpGeneral.TabIndex = 0;
			this.tpGeneral.Text = "General";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// tpAppearance
			// 
			this.tpAppearance.Location = new System.Drawing.Point(4, 22);
			this.tpAppearance.Name = "tpAppearance";
			this.tpAppearance.Size = new System.Drawing.Size(520, 268);
			this.tpAppearance.TabIndex = 1;
			this.tpAppearance.Text = "Appearance";
			this.tpAppearance.UseVisualStyleBackColor = true;
			// 
			// tpInstallation
			// 
			this.tpInstallation.Controls.Add(this.gbOverride);
			this.tpInstallation.Controls.Add(this.gbDetected);
			this.tpInstallation.Location = new System.Drawing.Point(4, 22);
			this.tpInstallation.Name = "tpInstallation";
			this.tpInstallation.Size = new System.Drawing.Size(520, 268);
			this.tpInstallation.TabIndex = 2;
			this.tpInstallation.Text = "Installation";
			this.tpInstallation.UseVisualStyleBackColor = true;
			// 
			// gbOverride
			// 
			this.gbOverride.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbOverride.Controls.Add(this.panelOverride);
			this.gbOverride.Controls.Add(this.cbOverride);
			this.gbOverride.Location = new System.Drawing.Point(8, 60);
			this.gbOverride.Name = "gbOverride";
			this.gbOverride.Size = new System.Drawing.Size(504, 200);
			this.gbOverride.TabIndex = 3;
			this.gbOverride.TabStop = false;
			this.gbOverride.Text = "Override";
			// 
			// panelOverride
			// 
			this.panelOverride.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelOverride.Controls.Add(this.cbOverrideFallback);
			this.panelOverride.Controls.Add(this.btnOverridePathBrowse);
			this.panelOverride.Controls.Add(this.tbOverridePathValue);
			this.panelOverride.Controls.Add(this.lblOverridePath);
			this.panelOverride.Location = new System.Drawing.Point(0, 40);
			this.panelOverride.Name = "panelOverride";
			this.panelOverride.Size = new System.Drawing.Size(504, 160);
			this.panelOverride.TabIndex = 1;
			// 
			// cbOverrideFallback
			// 
			this.cbOverrideFallback.AutoSize = true;
			this.cbOverrideFallback.Location = new System.Drawing.Point(6, 1);
			this.cbOverrideFallback.Name = "cbOverrideFallback";
			this.cbOverrideFallback.Size = new System.Drawing.Size(121, 17);
			this.cbOverrideFallback.TabIndex = 2;
			this.cbOverrideFallback.Text = "Only use as fallback";
			this.cbOverrideFallback.UseVisualStyleBackColor = true;
			// 
			// btnOverridePathBrowse
			// 
			this.btnOverridePathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOverridePathBrowse.Location = new System.Drawing.Point(474, 23);
			this.btnOverridePathBrowse.Name = "btnOverridePathBrowse";
			this.btnOverridePathBrowse.Size = new System.Drawing.Size(24, 22);
			this.btnOverridePathBrowse.TabIndex = 2;
			this.btnOverridePathBrowse.Text = "...";
			this.btnOverridePathBrowse.UseVisualStyleBackColor = true;
			this.btnOverridePathBrowse.Click += new System.EventHandler(this.Override_BrowsePath);
			// 
			// tbOverridePathValue
			// 
			this.tbOverridePathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOverridePathValue.Location = new System.Drawing.Point(44, 24);
			this.tbOverridePathValue.Name = "tbOverridePathValue";
			this.tbOverridePathValue.Size = new System.Drawing.Size(424, 20);
			this.tbOverridePathValue.TabIndex = 1;
			// 
			// lblOverridePath
			// 
			this.lblOverridePath.AutoSize = true;
			this.lblOverridePath.Location = new System.Drawing.Point(6, 27);
			this.lblOverridePath.Name = "lblOverridePath";
			this.lblOverridePath.Size = new System.Drawing.Size(32, 13);
			this.lblOverridePath.TabIndex = 0;
			this.lblOverridePath.Text = "Path:";
			// 
			// cbOverride
			// 
			this.cbOverride.AutoSize = true;
			this.cbOverride.Location = new System.Drawing.Point(6, 19);
			this.cbOverride.Name = "cbOverride";
			this.cbOverride.Size = new System.Drawing.Size(65, 17);
			this.cbOverride.TabIndex = 0;
			this.cbOverride.Text = "Enabled";
			this.cbOverride.UseVisualStyleBackColor = true;
			this.cbOverride.CheckedChanged += new System.EventHandler(this.Override_StateChanged);
			// 
			// gbDetected
			// 
			this.gbDetected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbDetected.Controls.Add(this.lblDetectedTypeValue);
			this.gbDetected.Controls.Add(this.lblDetectedType);
			this.gbDetected.Controls.Add(this.lblDetectedPath);
			this.gbDetected.Controls.Add(this.lblDetectedPathValue);
			this.gbDetected.Location = new System.Drawing.Point(8, 3);
			this.gbDetected.Name = "gbDetected";
			this.gbDetected.Size = new System.Drawing.Size(504, 51);
			this.gbDetected.TabIndex = 2;
			this.gbDetected.TabStop = false;
			this.gbDetected.Text = "Detected";
			// 
			// lblDetectedTypeValue
			// 
			this.lblDetectedTypeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDetectedTypeValue.AutoEllipsis = true;
			this.lblDetectedTypeValue.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblDetectedTypeValue.Location = new System.Drawing.Point(44, 29);
			this.lblDetectedTypeValue.Name = "lblDetectedTypeValue";
			this.lblDetectedTypeValue.Size = new System.Drawing.Size(454, 13);
			this.lblDetectedTypeValue.TabIndex = 3;
			this.lblDetectedTypeValue.TabStop = true;
			this.lblDetectedTypeValue.Text = "TYPE";
			// 
			// lblDetectedType
			// 
			this.lblDetectedType.AutoSize = true;
			this.lblDetectedType.Location = new System.Drawing.Point(6, 29);
			this.lblDetectedType.Name = "lblDetectedType";
			this.lblDetectedType.Size = new System.Drawing.Size(34, 13);
			this.lblDetectedType.TabIndex = 2;
			this.lblDetectedType.Text = "Type:";
			// 
			// lblDetectedPath
			// 
			this.lblDetectedPath.AutoSize = true;
			this.lblDetectedPath.Location = new System.Drawing.Point(6, 16);
			this.lblDetectedPath.Name = "lblDetectedPath";
			this.lblDetectedPath.Size = new System.Drawing.Size(32, 13);
			this.lblDetectedPath.TabIndex = 0;
			this.lblDetectedPath.Text = "Path:";
			// 
			// lblDetectedPathValue
			// 
			this.lblDetectedPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDetectedPathValue.AutoEllipsis = true;
			this.lblDetectedPathValue.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblDetectedPathValue.Location = new System.Drawing.Point(44, 16);
			this.lblDetectedPathValue.Name = "lblDetectedPathValue";
			this.lblDetectedPathValue.Size = new System.Drawing.Size(454, 13);
			this.lblDetectedPathValue.TabIndex = 1;
			this.lblDetectedPathValue.TabStop = true;
			this.lblDetectedPathValue.Text = "PATH";
			this.lblDetectedPathValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDetectedPathValue_LinkClicked);
			// 
			// WndSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 294);
			this.Controls.Add(this.tcMain);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WndSettings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "WndSettings";
			this.tcMain.ResumeLayout(false);
			this.tpInstallation.ResumeLayout(false);
			this.gbOverride.ResumeLayout(false);
			this.gbOverride.PerformLayout();
			this.panelOverride.ResumeLayout(false);
			this.panelOverride.PerformLayout();
			this.gbDetected.ResumeLayout(false);
			this.gbDetected.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpGeneral;
		private System.Windows.Forms.TabPage tpAppearance;
		private System.Windows.Forms.TabPage tpInstallation;
		private System.Windows.Forms.LinkLabel lblDetectedPathValue;
		private System.Windows.Forms.Label lblDetectedPath;
		private System.Windows.Forms.GroupBox gbDetected;
		private System.Windows.Forms.LinkLabel lblDetectedTypeValue;
		private System.Windows.Forms.Label lblDetectedType;
		private System.Windows.Forms.CheckBox cbOverride;
		private System.Windows.Forms.GroupBox gbOverride;
		private System.Windows.Forms.Panel panelOverride;
		private System.Windows.Forms.Button btnOverridePathBrowse;
		private System.Windows.Forms.TextBox tbOverridePathValue;
		private System.Windows.Forms.Label lblOverridePath;
		private System.Windows.Forms.CheckBox cbOverrideFallback;
	}
}
