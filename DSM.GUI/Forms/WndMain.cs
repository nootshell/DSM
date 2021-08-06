using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Menu;

using DSM.API;
using DSM.API.Plugins.Modules;
using DSM.API.Utilities;
using DSM.GUI.Utilities;
using DSM.API.Directories;
using DSM.API.Directories.Subdirectories;
using DSM.API.Plugins;
using System.IO;
using DSM.API.Extensions;

namespace DSM.GUI.Forms {

	public partial class WndMain : Form {

		private TabPage[] ModuleTabs { get; set; }
		public DSMContext Context { get; set; }

		private BindingSource moduleDataSource = new BindingSource() { DataSource = typeof(Module) };

		public Module SelectedModule {
			get => (Module)this.moduleDataSource.DataSource;
			set => this.moduleDataSource.DataSource = value;
		}




		public WndMain() {
			this.InitializeComponent();


			this.Icon = Properties.Resources.Icon;

			this.tvModules.ImageList = new ImageList();
			this.tvModules.ImageList.Images.Add(Strings.CORE, Properties.Resources.IconCore);
			this.tvModules.ImageList.Images.Add(Strings.MODS, Properties.Resources.IconMods);
			this.tvModules.ImageList.Images.Add(typeof(Aircraft).Name, Properties.Resources.IconAircraft);
			this.tvModules.ImageList.Images.Add(typeof(Terrain).Name, Properties.Resources.IconTerrain);

			this.tcModule.ImageList = new ImageList();
			this.tcModule.ImageList.Images.Add(this.tpModuleInfo.Text, Properties.Resources.IconInformation);
			this.tcModule.ImageList.Images.Add(this.tpModuleLiveries.Text, Properties.Resources.IconLiveries);
			this.tcModule.ImageList.Images.Add(this.tpModuleCountermeasures.Text, Properties.Resources.IconCountermeasures);


			/* Set tooltips where required. */
			ToolTip tooltip = new ToolTip();
			tooltip.SetToolTip(this.lblModuleInfoInstallationPathValue, Strings.OPEN_INSTALLDIR_IN_EXPLORER);


			/* Populate module tabs array
			** Adding a TabPage to a TabControl removes it from its initial TabControl's collection, so we can't use the
			** template TabControl's collection for tab page repopulation. */
			int i = this.tctModule.TabPages.Count;
			this.ModuleTabs = new TabPage[i];
			for (; i-- > 0;) {
				this.ModuleTabs[i] = this.tctModule.TabPages[i];
			}


			this.AddModuleDatabind(
				nameof(this.SelectedModule.Path),
				this.lblModuleInfoInstallationPathValue,
				nameof(this.lblModuleInfoInstallationPathValue.Text)
			);

			this.AddModuleDatabind(
				nameof(this.SelectedModule.Icon),
				this.pbModuleInfoIcon,
				nameof(this.pbModuleInfoIcon.Image)
			);

			this.AddModuleDatabind(
				nameof(this.SelectedModule.Name),
				this.lblModuleInfoDetailsNameValue,
				nameof(this.lblModuleInfoDetailsNameValue.Text)
			);

			this.AddModuleDatabind(
				nameof(this.SelectedModule.Version),
				this.lblModuleInfoDetailsVersionValue,
				nameof(this.lblModuleInfoDetailsVersionValue.Text)
			);

			this.AddModuleDatabind(
				nameof(this.SelectedModule.Developer),
				this.lblModuleInfoDetailsDeveloperValue,
				nameof(this.lblModuleInfoDetailsDeveloperValue.Text)
			);

			this.AddModuleDatabind(
				nameof(this.SelectedModule.UpdateSlug),
				this.lblModuleInfoDetailsSlugUpdateValue,
				nameof(this.lblModuleInfoDetailsSlugUpdateValue.Text)
			);

			this.AddModuleDatabind(
				nameof(this.SelectedModule.PrettyFilesystemSlugs),
				this.lblModuleInfoDetailsSlugFilesystemValue,
				nameof(this.lblModuleInfoDetailsSlugFilesystemValue.Text)
			);

			this.AddModuleDatabind(
				nameof(this.SelectedModule.Info),
				this.lblModuleInfoDetailsDescriptionValue,
				nameof(this.lblModuleInfoDetailsDescriptionValue.Text),
				"No description available."
			);

			this.moduleDataSource.CurrentItemChanged += this.ModuleDataSource_CurrentItemChanged;

			this.UpdateTitle();
		}

		private void ModuleDataSource_CurrentItemChanged(object sender, EventArgs e) {
			this.ReconfigureShownLiveries(this.SelectedModule);
		}

		protected void AddModuleDatabind(string moduleProperty, Control control, string controlProperty, string nullStr = "Unknown") {
			_ = control.DataBindings.Add(
				controlProperty,
				this.moduleDataSource,
				moduleProperty,
				true,
				DataSourceUpdateMode.OnPropertyChanged,
				nullStr
			);
		}




		protected virtual TreeNode BuildModuleCategoryNode<TModule>(ModuleDirectory directory, ImageList imageList) where TModule : Module, new() {
			Type type;
			Image icon;
			string key_img;
			TreeNode root = null;
			foreach (TModule module in directory.GetModules<TModule>()) {
				if (root == null) {
					type = module.GetType();
					root = new TreeNode(type.Name) { Tag = type };
				}

				key_img = null;
				icon = module.Icon;

				if (icon != null) {
					key_img = SlugHelper.GetSlug(module.Path); // FIXME?

					imageList.Images.Add(key_img, icon);
				}

				_ = root.Nodes.Add(new TreeNode(module.GetName()) { ImageKey = key_img, SelectedImageKey = key_img, Tag = module });
			}

			if (root != null) {
				root.ImageKey = root.SelectedImageKey = typeof(TModule).Name;
				root.Expand();
			}

			return root;
		}


		protected virtual TreeNode BuildRootNode(string name, string imageKey, ModuleDirectory directory, ImageList imageList) {
			TreeNode root = new TreeNode(name);
			root.ImageKey = root.SelectedImageKey = imageKey;

			bool any = false;
			TreeNode node;

			node = this.BuildModuleCategoryNode<Aircraft>(directory, imageList);
			if (node != null) {
				any = true;
				_ = root.Nodes.Add(node);
			}

			node = this.BuildModuleCategoryNode<Terrain>(directory, imageList);
			if (node != null) {
				any = true;
				_ = root.Nodes.Add(node);
			}

			if (!any) {
				_ = root.Nodes.Add(new TreeNode("Nothing found :[") { ForeColor = Color.Firebrick });
			}

			root.Expand();
			return root;
		}




		protected void ReconfigureShownTabs(Module module) {
			/*this.tcModule.SuspendLayout();

			TabPage selected = this.tcModule.SelectedTab;*/
			this.tcModule.TabPages.Clear();

			Type type = module.GetType();
			string typeName = type.Name;
			foreach (TabPage page in this.ModuleTabs) {
				if ((page.Tag is string allowType && allowType == typeName) || !(page.Tag is string)) {
					this.tcModule.TabPages.Add(page);
					page.ImageKey = page.Text;
				}
			}

			/*if (selected != null && this.tcModule.TabPages.Contains(selected)) {
				this.tcModule.SelectTab(selected);
			}

			this.tcModule.Refresh();
			this.tcModule.ResumeLayout();*/
		}


		protected ListViewItem MkListViewItem(Livery livery) {
			return new ListViewItem(new string[] {
				livery.Name,
				SlugHelper.GetSlug(livery.Path),
				livery.GetPrimaryPathInfo().Type.ToDescriptiveString(),
				Humanize.FileSize(livery.GetPrimaryPathInfo().Size)
			});
		}


		protected void ReconfigureShownLiveries(Module module) {
			this.lvLiveries.Items.Clear();

			foreach (Livery livery in module.GetLiveries(this.Context.StateDirectory)) {
				_ = this.lvLiveries.Items.Add(this.MkListViewItem(livery));
			}

			this.lvLiveries.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}


		protected void UpdateTitle() {
			string title = Strings.TITLE;

			if (this.Context?.StateDirectory != null) {
				title += $" [Variant: {this.Context.StateDirectory.Name}]";
			}

			this.Text = title;
		}




		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			if (this.Context == null) {
				throw new InvalidOperationException();
			}

			MenuItemCollection variants = this.menuOptionsItemVariant.MenuItems;
			foreach (StateDirectory variant in this.Context.StateDirectoryManager.GetStateDirectories()) {
				_ = variants.Add(
					new MenuItem(variant.Name, this.OnMenuItem_Variant) {
						RadioCheck = true,
						Tag = variant.Name,
						Checked = (variant == this.Context.StateDirectory)
					}
				);
			}

			_ = this.tvModules.Nodes.Add(this.BuildRootNode(Strings.CORE, Strings.CORE, this.Context.InstallationDirectory.Mods, this.tvModules.ImageList));
			_ = this.tvModules.Nodes.Add(this.BuildRootNode(Strings.MODS, Strings.MODS, this.Context.StateDirectory.Mods, this.tvModules.ImageList));

			this.tvModules.SelectedNode = this.tvModules.Nodes[0];

			this.UpdateTitle();
			this.OnTreeView_AfterSelect(this.tvModules, null);
		}




		private void OnMenuItem_Settings(object sender, EventArgs e) {
			_ = (new WndSettings() { Context = this.Context }).ShowDialog(this);
		}

		private void OnMenuItem_About(object sender, EventArgs e) {
			_ = (new WndAbout()).ShowDialog(this);
		}

		private void OnMenuItem_Restart(object sender, EventArgs e) {
			Application.Restart();
		}

		private void OnMenuItem_Exit(object sender, EventArgs e) {
			Application.Exit();
		}

		private void OnMenuItem_Variant(object sender, EventArgs e) {
			MenuItemCollection variants = this.menuOptionsItemVariant.MenuItems;

			MenuItem oldVariant = null;
			foreach (MenuItem item in variants) {
				if (item.Checked) {
					oldVariant = item;
					break;
				}
			}

			if (oldVariant == null) {
				throw new InvalidOperationException();
			}

			MenuItem newVariant = (MenuItem)sender;
			if (oldVariant == newVariant) {
				return;
			}

			if (!this.Context.SetStateDirectory((string)newVariant.Tag)) {
				return;
			}

			newVariant.Checked = true;
			oldVariant.Checked = false;

			this.UpdateTitle();
		}

		private void OnTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
			TreeView tv = (TreeView)sender;
			TreeNode node = tv.SelectedNode;

			if (!(this.pModule.Visible = (node?.Tag is Module))) {
				return;
			}

			Module module = (node.Tag as Module);
			this.SelectedModule = module;
			this.ReconfigureShownTabs(module);
			this.UpdateTitle();
		}

		private void OnLinkClicked_OpenFolder(object sender, LinkLabelLinkClickedEventArgs e)
			=> DefaultEvents.OnLinkClicked_OpenFolder(sender, e);

		private void OnLiveriesRefresh(object sender, EventArgs e)
			=> this.ReconfigureShownLiveries(this.SelectedModule);

		private void OnLiveriesExplore(object sender, EventArgs e) {
			string path = Normalize.FilesystemPath($"{this.Context.StateDirectory.Path}/Liveries/{this.SelectedModule.GetFirstFilesystemSlug()}");

			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}

			DefaultEvents.ExploreFolder(path);
		}

		private void OnSelectedLiveryChanged(object sender, EventArgs e) {
			ListView lv = (sender as ListView);
			if (lv == null) {
				return;
			}

			bool enabled = (lv.SelectedItems?.Count > 0);
			btnLiveriesEnable.Enabled = enabled;
			btnLiveriesDisable.Enabled = enabled;
			btnLiveriesUninstall.Enabled = enabled;
		}
	}

}
