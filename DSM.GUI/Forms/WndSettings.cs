using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using DSM.API;
using DSM.API.Directories;
using DSM.API.Directories.Managers;
using DSM.API.Utilities;
using DSM.GUI.Utilities;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace DSM.GUI.Forms {

	public partial class WndSettings : Form {

		public DSMContext Context { get; set; }




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

			if (this.Context == null) {
				throw new InvalidOperationException();
			}

			ToolTip tooltip = new ToolTip();
			tooltip.SetToolTip(this.cbOverrideFallback, "Select this to use the override path as a fallback path instead, in case the installation cannot be detected at runtime.");

			string path = this.Context.Installation.Path;
			this.lblDetectedPathValue.Text = path;
			this.lblDetectedPathValue.LinkArea = new LinkArea(0, path.Length);
			tooltip.SetToolTip(this.lblDetectedPathValue, Strings.OPEN_INSTALLDIR_IN_EXPLORER);

			InstallationDirectory.DirectoryType typeV = this.Context.Installation.Type;
			string homepage = this.Context.Installation.Homepage;
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
			using (CommonOpenFileDialog dialog = new CommonOpenFileDialog()) {
				dialog.Title = $"Select {(this.cbOverrideFallback.Checked ? "a fallback" : "an override")} installation folder";
				dialog.IsFolderPicker = true;
				dialog.EnsurePathExists = true;
				dialog.Multiselect = false;

				bool found = false;
				string path_norm = Normalize.FilesystemPath(this.tbOverridePathValue.Text);
				if (Directory.Exists(path_norm)) {
					found = true;
				} else {
					string path_proc = Normalize.ProcessableFilesystemPath(path_norm);

					int idx;
					while ((idx = path_proc.LastIndexOf("/")) > 0) {
						path_proc = path_proc.Substring(0, idx);
						path_norm = Normalize.FilesystemPath(path_proc);

						if (Directory.Exists(path_norm)) {
							found = true;
							break;
						}
					}
				}

				if (!found) {
					path_norm = Normalize.FilesystemPath(this.Context.Installation.Path);
					if (!Directory.Exists(path_norm)) {
						path_norm = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
					}
				}

				dialog.InitialDirectory = Path.GetDirectoryName(path_norm);
				dialog.DefaultDirectory = dialog.DefaultFileName = Path.GetFileName(path_norm);

				CommonFileDialogResult result = dialog.ShowDialog(this.Handle);
				if (result == CommonFileDialogResult.Ok) {
					string path = dialog.FileName;

					InstallationDirectory.DirectoryType type = InstallationDirectoryManager.VerifyInstallation(path);
					if (type != InstallationDirectory.DirectoryType.Unknown || MessageBox.Show(this, Strings.USE_UNVERIFIED_FOLDER, Strings.WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
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
