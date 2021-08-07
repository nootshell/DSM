
namespace DSM.GUI.Forms.Controls {
	partial class PluginPathConfigurer {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.cbType = new DSM.GUI.Forms.Controls.PluginPathTypeBox();
			this.lblPath = new System.Windows.Forms.LinkLabel();
			this.btnSetPath = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbType
			// 
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(3, 3);
			this.cbType.Name = "cbType";
			this.cbType.SelectedType = DSM.API.Plugins.Base.PluginPathType.Unknown;
			this.cbType.Size = new System.Drawing.Size(93, 21);
			this.cbType.TabIndex = 0;
			// 
			// lblPath
			// 
			this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPath.AutoEllipsis = true;
			this.lblPath.Location = new System.Drawing.Point(102, 8);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(164, 13);
			this.lblPath.TabIndex = 1;
			this.lblPath.TabStop = true;
			this.lblPath.Text = "PATH";
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnSetPath
			// 
			this.btnSetPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSetPath.Location = new System.Drawing.Point(272, 3);
			this.btnSetPath.Name = "btnSetPath";
			this.btnSetPath.Size = new System.Drawing.Size(25, 23);
			this.btnSetPath.TabIndex = 2;
			this.btnSetPath.Text = "...";
			this.btnSetPath.UseVisualStyleBackColor = true;
			this.btnSetPath.Click += new System.EventHandler(this.HandleSetPath);
			// 
			// PluginPathConfigurer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnSetPath);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.cbType);
			this.Name = "PluginPathConfigurer";
			this.Size = new System.Drawing.Size(300, 38);
			this.ResumeLayout(false);

		}

		#endregion

		private PluginPathTypeBox cbType;
		private System.Windows.Forms.LinkLabel lblPath;
		private System.Windows.Forms.Button btnSetPath;
	}
}
