using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Menu;

using DSM.API;
using DSM.API.Modules;
using DSM.API.Utilities;
using DSM.GUI.Utilities;




namespace DSM.GUI.Forms {

	public partial class WndMain : Form {

		private TabPage[] ModuleTabs { get; set; }
		public DSMContext Context { get; set; }

		private BindingSource moduleDataSource = new BindingSource() { DataSource = typeof(Module) };

		public Module SelectedModule {
			get => (Module)this.moduleDataSource.DataSource;
			set => this.moduleDataSource.DataSource = value;
		}

		public string SelectedVariant { get; set; }




		public WndMain() {
			this.InitializeComponent();
			this.Icon = Properties.Resources.Icon;

			this.tvModules.ImageList = new ImageList();
			this.tvModules.ImageList.Images.Add(Strings.CORE, Properties.Resources.IconCore);
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
				nameof(this.SelectedModule.InstallPath),
				this.lblModuleInfoInstallationPathValue,
				nameof(this.lblModuleInfoInstallationPathValue.Text)
			);

			this.AddModuleDatabind(
				nameof(this.SelectedModule.IconPathAbsolute),
				this.pbModuleInfoIcon,
				nameof(this.pbModuleInfoIcon.ImageLocation)
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


			this.menuOptionsItemVariantDefault.Tag = Strings.DEFAULT_VARIANT;

			this.UpdateTitle();
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


		protected virtual TreeNode BuildModuleTypeNode<TModule>(ImageList imageList) where TModule : Module, new() {
			Type type;
			string key_img;
			TreeNode root = null;
			foreach (TModule module in this.Context.Installation.GetModules<TModule>()) {
				if (root == null) {
					type = module.GetType();
					root = new TreeNode(type.Name) { Tag = type };
				}

				key_img = null;

				if (module.IconPathRelative != null) {
					key_img = module.InstallPathSlug;

					imageList.Images.Add(
						key_img,
						Image.FromFile(
							Normalize.FilesystemPath($"{module.InstallPath}/{module.IconPathRelative}")
						)
					);
				}

				_ = root.Nodes.Add(new TreeNode(module.GetName()) { ImageKey = key_img, SelectedImageKey = key_img, Tag = module });
			}

			if (root != null) {
				root.ImageKey = root.SelectedImageKey = typeof(TModule).Name;
				root.Expand();
			}

			return root;
		}


		protected void ReconfigureShownTabs(Module module) {
			this.tcModule.TabPages.Clear();

			Type type = module.GetType();
			string typeName = type.Name;
			foreach (TabPage page in this.ModuleTabs) {
				if ((page.Tag is string allowType && allowType == typeName) || !(page.Tag is string)) {
					this.tcModule.TabPages.Add(page);
					page.ImageKey = page.Text;
				}
			}
		}


		protected void UpdateTitle() {
			string title = Strings.TITLE;

			if (this.SelectedVariant != null && this.SelectedVariant != Strings.DEFAULT_VARIANT) {
				title += $" ({this.SelectedVariant})";
			}

			this.Text = title;
		}




		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			if (this.Context == null) {
				throw new InvalidOperationException();
			}

			bool skip, added = false;
			MenuItemCollection variants = this.menuOptionsItemVariant.MenuItems;
			foreach (string variant in StateManager.ExistingVariants) {
				skip = false;

				foreach (MenuItem item in variants) {
					if (item.Tag is string item_var && item_var == variant) {
						skip = true;
						break;
					}
				}

				if (skip) {
					continue;
				}

				_ = variants.Add(new MenuItem(variant, this.OnMenuItem_Variant) { RadioCheck = true, Tag = variant });
				added = true;
			}

			MenuItem selectedVariant = null;
			if (added) {
				selectedVariant = this.menuOptionsItemVariantDefault;

				// TODO: determine default variant
				this.menuOptionsItemVariantDefault.Checked = true;
			} else {
				selectedVariant = this.menuOptionsItemVariantDefault;

				this.menuOptionsItemVariantDefault.Checked = true;
				this.menuOptionsItemVariantDefault.Enabled = false;
				this.menuOptionsItemVariantSeparator.Visible = false;
			}

			if (selectedVariant != null) {
				selectedVariant.PerformClick();
			}


			TreeNode root = new TreeNode(Strings.CORE);
			root.ImageKey = root.SelectedImageKey = Strings.CORE;

			// TODO: dynamic
			TreeNode aircraft = this.BuildModuleTypeNode<Aircraft>(this.tvModules.ImageList);
			if (aircraft != null) {
				_ = root.Nodes.Add(aircraft);
			}

			// TODO: dynamic
			TreeNode terrains = this.BuildModuleTypeNode<Terrain>(this.tvModules.ImageList);
			if (terrains != null) {
				_ = root.Nodes.Add(terrains);
			}

			if (aircraft == null && terrains == null) {
				_ = root.Nodes.Add(new TreeNode("Nothing found :[") { ForeColor = Color.Firebrick });
			}

			root.Expand();
			_ = this.tvModules.Nodes.Add(root);


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

			MenuItem newVariant = (MenuItem)sender;
			MenuItem curVariant = null;
			foreach (MenuItem item in variants) {
				if (!item.Checked) {
					continue;
				}

				curVariant = item;
				break;
			}

			if (curVariant == null) {
				throw new InvalidOperationException();
			}

			if (curVariant == newVariant) {
				if (this.SelectedVariant == null) {
					this.SelectedVariant = (string)newVariant.Tag;
				}

				return;
			}

			newVariant.Checked = true;
			curVariant.Checked = false;
			this.SelectedVariant = (string)newVariant.Tag;
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

	}

}
