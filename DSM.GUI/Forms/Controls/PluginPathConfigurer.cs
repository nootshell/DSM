using DSM.API.Plugins.Base;
using DSM.GUI.Utilities;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSM.GUI.Forms.Controls {

	public partial class PluginPathConfigurer : UserControl {

		public PluginPathInfo PathInfo { get; protected set; }

		private bool readOnly = false;
		[DefaultValue(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public bool ReadOnly {
			get => this.readOnly;
			set {
				this.readOnly = value;
				this.RestoreControlState();
			}
		}

		private bool canChangeType = false;
		[DefaultValue(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public bool CanChangeType {
			get => this.canChangeType;
			set {
				this.canChangeType = value;
				this.RestoreControlState();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PluginPathType SelectedType {
			get => this.cbType.SelectedType;
			set => this.cbType.SelectedType = value;
		}

		private string suffix = null;
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string Suffix {
			get => this.suffix;
			set {
				this.suffix = value;
				this.RestoreControlState();
			}
		}




		public PluginPathConfigurer() {
			this.InitializeComponent();

			this.lblPath.LinkClicked += DefaultEvents.OnLinkClicked_OpenFileOrFolder;

			this.RestoreControlState();
		}




		private void HandleSetPath(object sender, EventArgs e) {
			using (CommonOpenFileDialog dialog = new CommonOpenFileDialog()) {
				dialog.Title = $"Select titties";

				switch (this.SelectedType) {
					case PluginPathType.ZipArchive:
						dialog.IsFolderPicker = false;
						break;

					default:
						dialog.IsFolderPicker = true;
						break;
				}

				dialog.EnsurePathExists = true;
				dialog.Multiselect = false;
				dialog.RestoreDirectory = true;

				CommonFileDialogResult result = dialog.ShowDialog(this.Handle);
				if (result == CommonFileDialogResult.Ok) {
					string path = dialog.FileName;
					this.PathInfo = new TargetInfo(path, this.SelectedType);
					this.RestoreControlState();
				}
			}
		}




		protected virtual void RestoreControlState() {
			if (this.PathInfo is PluginPathInfo path) {
				this.cbType.SelectedType = path.Type;

				this.lblPath.Text = $"{path.Path}{this.Suffix}";
				this.lblPath.LinkArea = new LinkArea(0, path.Path.Length);
				this.lblPath.Enabled = true;
			} else {
				this.lblPath.Text = "Idle...";
				this.lblPath.LinkArea = new LinkArea();
				this.lblPath.Enabled = false;
			}

			bool enabled = !this.ReadOnly;
			this.cbType.Enabled = enabled && this.CanChangeType;
			this.btnSetPath.Enabled = enabled;
		}




		public virtual void SetPathInfo(PluginPathInfo pathInfo, bool autoReadOnly = true) {
			this.PathInfo = pathInfo;

			this.RestoreControlState();
		}
	}
	
}
