using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using DSM.API.Installations;
using DSM.GUI.Utilities;




namespace DSM.GUI.Forms {

	public partial class WndSettings : Form {

		public WndSettings() {
			this.InitializeComponent();
			this.Icon = Properties.Resources.IconSettings;

			this.Override_StateChanged(this.cbOverride, null);
			this.UpdateTitle();
		}




		protected void UpdateTitle() {
			this.Text = $"{Strings.TITLE} - Settings - {this.tcMain.SelectedTab.Text}";
		}




		protected override void OnLoad(EventArgs ev) {
			base.OnLoad(ev);

			ToolTip tooltip = new ToolTip();
			tooltip.SetToolTip(this.cbOverrideFallback, "Select this to use the override path as a fallback path instead, in case the installation cannot be detected at runtime.");

			string path = Installation.Detected.Path;
			this.lblDetectedPathValue.Text = path;
			this.lblDetectedPathValue.LinkArea = new LinkArea(0, path.Length);
			tooltip.SetToolTip(this.lblDetectedPathValue, Strings.OPEN_INSTALLDIR_IN_EXPLORER);

			InstallationType typeV = Installation.Detected.Type;
			string homepage = Installation.GetTypeHomepage(typeV);
			string type = typeV.ToString();
			this.lblDetectedTypeValue.Text = type;
			this.lblDetectedTypeValue.LinkArea = new LinkArea(0, ((homepage != null) ? type.Length : 0));
			this.lblDetectedTypeValue.LinkClicked += (s, e) => {
				if (homepage == null) {
					return;
				}

				_ = Process.Start(new ProcessStartInfo(homepage) { UseShellExecute = true });
			};
			if (homepage != null) {
				tooltip.SetToolTip(this.lblDetectedTypeValue, $"Open the {type} homepage in your browser ({homepage}).");
			}
		}




		private void Override_StateChanged(object sender, EventArgs e) {
			bool enabled = ((CheckBox)sender).Checked;
			this.panelOverride.Enabled = enabled;
			this.cbOverrideFallback.Enabled = enabled;
		}


		private void Override_BrowsePath(object sender, EventArgs e) {
			using (FolderBrowserDialog dialog = new FolderBrowserDialog()) {
				dialog.Description = $"Select a folder to use as installation path {(this.cbOverrideFallback.Checked ? "fallback" : "override")}.";
				dialog.ShowNewFolderButton = false;

				if (Directory.Exists(this.tbOverridePathValue.Text)) {
					dialog.SelectedPath = this.tbOverridePathValue.Text;
				} else if (Directory.Exists(Installation.Detected.Path)) {
					dialog.SelectedPath = Installation.Detected.Path;
				} else {
					// something smart here (e.g. quick dir scan or whatever)
				}

				DialogResult result = dialog.ShowDialog(this);
				if (result == DialogResult.OK) {
					string path = dialog.SelectedPath;

					InstallationType type = Installation.VerifyInstallation(path);
					if (type != InstallationType.Unknown || MessageBox.Show(this, Strings.USE_UNVERIFIED_FOLDER, Strings.WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
						this.tbOverridePathValue.Text = path;

						// TODO: do something with it
					}
				}
			}
		}

		private void lblDetectedPathValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> DefaultEvents.OnLinkClicked_OpenFolder(sender, e);

		private void OnTabControl_IndexChanged(object sender, EventArgs e)
			=> this.UpdateTitle();

	}

}
