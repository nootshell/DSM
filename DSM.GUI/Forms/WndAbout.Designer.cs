namespace DSM.GUI.Forms {
	partial class WndAbout {
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
			this.lblCreditIconNonModule = new System.Windows.Forms.LinkLabel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblAuthorsValue = new System.Windows.Forms.Label();
			this.lblAuthors = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblCreditIconModule = new System.Windows.Forms.Label();
			this.lblCreditED = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblCreditIconNonModule
			// 
			this.lblCreditIconNonModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCreditIconNonModule.AutoSize = true;
			this.lblCreditIconNonModule.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.lblCreditIconNonModule.LinkArea = new System.Windows.Forms.LinkArea(29, 40);
			this.lblCreditIconNonModule.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblCreditIconNonModule.LinkColor = System.Drawing.Color.CornflowerBlue;
			this.lblCreditIconNonModule.Location = new System.Drawing.Point(83, 132);
			this.lblCreditIconNonModule.Margin = new System.Windows.Forms.Padding(0);
			this.lblCreditIconNonModule.Name = "lblCreditIconNonModule";
			this.lblCreditIconNonModule.Size = new System.Drawing.Size(365, 17);
			this.lblCreditIconNonModule.TabIndex = 0;
			this.lblCreditIconNonModule.TabStop = true;
			this.lblCreditIconNonModule.Text = "Non-module icons by Freepik (https://www.flaticon.com/authors/freepik).";
			this.lblCreditIconNonModule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblCreditIconNonModule.UseCompatibleTextRendering = true;
			this.lblCreditIconNonModule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLinkLabel_ProcessStart);
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(82, 16);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.lblTitle.Size = new System.Drawing.Size(422, 34);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "TITLE";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblAuthorsValue
			// 
			this.lblAuthorsValue.AutoSize = true;
			this.lblAuthorsValue.Location = new System.Drawing.Point(104, 77);
			this.lblAuthorsValue.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
			this.lblAuthorsValue.Name = "lblAuthorsValue";
			this.lblAuthorsValue.Size = new System.Drawing.Size(60, 13);
			this.lblAuthorsValue.TabIndex = 2;
			this.lblAuthorsValue.Text = "AUTHORS";
			// 
			// lblAuthors
			// 
			this.lblAuthors.AutoSize = true;
			this.lblAuthors.Location = new System.Drawing.Point(95, 64);
			this.lblAuthors.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
			this.lblAuthors.Name = "lblAuthors";
			this.lblAuthors.Size = new System.Drawing.Size(46, 13);
			this.lblAuthors.TabIndex = 3;
			this.lblAuthors.Text = "Authors:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::DSM.GUI.Properties.Resources.IconPng;
			this.pictureBox1.Location = new System.Drawing.Point(12, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 64);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// lblCreditIconModule
			// 
			this.lblCreditIconModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCreditIconModule.AutoSize = true;
			this.lblCreditIconModule.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.lblCreditIconModule.Location = new System.Drawing.Point(114, 119);
			this.lblCreditIconModule.Margin = new System.Windows.Forms.Padding(0);
			this.lblCreditIconModule.Name = "lblCreditIconModule";
			this.lblCreditIconModule.Size = new System.Drawing.Size(334, 13);
			this.lblCreditIconModule.TabIndex = 4;
			this.lblCreditIconModule.Text = "Module icons are sourced directly from your DCS installation directory.";
			// 
			// lblCreditED
			// 
			this.lblCreditED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCreditED.AutoSize = true;
			this.lblCreditED.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.lblCreditED.Location = new System.Drawing.Point(209, 106);
			this.lblCreditED.Margin = new System.Windows.Forms.Padding(0);
			this.lblCreditED.Name = "lblCreditED";
			this.lblCreditED.Size = new System.Drawing.Size(239, 13);
			this.lblCreditED.TabIndex = 5;
			this.lblCreditED.Text = "Thank you for making our dreams come true, ED.";
			// 
			// WndAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 155);
			this.Controls.Add(this.lblCreditED);
			this.Controls.Add(this.lblCreditIconModule);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblAuthors);
			this.Controls.Add(this.lblAuthorsValue);
			this.Controls.Add(this.lblCreditIconNonModule);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WndAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel lblCreditIconNonModule;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblAuthorsValue;
		private System.Windows.Forms.Label lblAuthors;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblCreditIconModule;
		private System.Windows.Forms.Label lblCreditED;
	}
}
