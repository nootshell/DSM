
namespace DSM.GUI.Forms {
	partial class WndInstall {
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
			this.lblSource = new System.Windows.Forms.Label();
			this.lblTarget = new System.Windows.Forms.Label();
			this.pluginPathConfigurer4 = new DSM.GUI.Forms.Controls.PluginPathConfigurer();
			this.pluginPathConfigurer3 = new DSM.GUI.Forms.Controls.PluginPathConfigurer();
			this.SuspendLayout();
			// 
			// lblSource
			// 
			this.lblSource.AutoSize = true;
			this.lblSource.Location = new System.Drawing.Point(24, 13);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(44, 13);
			this.lblSource.TabIndex = 2;
			this.lblSource.Text = "Source:";
			// 
			// lblTarget
			// 
			this.lblTarget.AutoSize = true;
			this.lblTarget.Location = new System.Drawing.Point(27, 59);
			this.lblTarget.Name = "lblTarget";
			this.lblTarget.Size = new System.Drawing.Size(41, 13);
			this.lblTarget.TabIndex = 3;
			this.lblTarget.Text = "Target:";
			// 
			// pluginPathConfigurer4
			// 
			this.pluginPathConfigurer4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pluginPathConfigurer4.CanChangeType = false;
			this.pluginPathConfigurer4.Location = new System.Drawing.Point(113, 59);
			this.pluginPathConfigurer4.Name = "pluginPathConfigurer4";
			this.pluginPathConfigurer4.Size = new System.Drawing.Size(474, 41);
			this.pluginPathConfigurer4.TabIndex = 1;
			// 
			// pluginPathConfigurer3
			// 
			this.pluginPathConfigurer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pluginPathConfigurer3.CanChangeType = false;
			this.pluginPathConfigurer3.Location = new System.Drawing.Point(113, 12);
			this.pluginPathConfigurer3.Name = "pluginPathConfigurer3";
			this.pluginPathConfigurer3.ReadOnly = true;
			this.pluginPathConfigurer3.Size = new System.Drawing.Size(474, 41);
			this.pluginPathConfigurer3.TabIndex = 0;
			// 
			// WndInstall
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 355);
			this.Controls.Add(this.lblTarget);
			this.Controls.Add(this.lblSource);
			this.Controls.Add(this.pluginPathConfigurer4);
			this.Controls.Add(this.pluginPathConfigurer3);
			this.Name = "WndInstall";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "WndInstall";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.PluginPathConfigurer pluginPathConfigurer3;
		private Controls.PluginPathConfigurer pluginPathConfigurer4;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.Label lblTarget;
	}
}
