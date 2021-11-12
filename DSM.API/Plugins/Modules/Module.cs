using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Relua;
using Relua.AST;

using DSM.API.Utilities;
using DSM.API.Directories.Subdirectories;
using DSM.API.Directories;
using DSM.API.Plugins.Base;
using System.Drawing;
using DSM.API.Extensions;

namespace DSM.API.Plugins.Modules {

	[PluginEntryFile("entry.lua")]
	public abstract class Module : Plugin {

		private static readonly string[] IconPaths = new string[] {
			"Theme/icon.png",
			"Theme/1/icon.png",
			"Skins/icon.png",
			"Skins/1/icon.png",
		};

		public static readonly Type[] DerivativeTypes = typeof(Module).GetDerivativeTypes().ToArray();

		public string UpdateSlug { get; set; }
		public string[] FilesystemSlugs { get; set; }

		public string ShortName { get; set; }

		public string Developer { get; set; }
		public string Info { get; set; }
		public string Version { get; set; }

		public string Name { get; set; }




		private Image __icon;
		public Image Icon {
			get {
				if (this.__icon == null) {
					this.__icon = this.GetIcon();
				}

				return this.__icon;
			}
		}




		protected Module() : base() { }
		protected Module(string path, bool installed) : base(path, installed) { }




		protected virtual void ParsePluginDeclaration(Block block, FunctionCall function, IStatement origin) {
			if (function.Arguments.Count < 1) {
				throw new InvalidCastException();
			}

			IExpression arg1 = function.Arguments[1];

			TableConstructor ctor = null;
			if (arg1 is Variable var) {
				ctor = LuaHelper.FindVariableValue<TableConstructor>(block, var.Name, null, origin);
			} else if (arg1 is TableConstructor tctor) {
				ctor = tctor;
			}

			if (ctor == null) {
				throw new InvalidOperationException();
			}

			foreach (TableConstructor.Entry entry in ctor.Entries) {
				string key = LuaHelper.GetExpressionStringValue(entry.Key);

				// XXX: Disabled bool parsing for now, installation status is provided by the Plugin base class
				if (false) {/*entry.Value is BoolLiteral boolLiteral) {
					bool value = boolLiteral.Value;

					switch (key) {
						// utterly useless afaik, every module that gets through here is by definition installed. however, keeping this here as an example.
						case "installed":
							this.Installed = value;
							break;

						default: break;
					}*/
				} else {
					string value = LuaHelper.GetExpressionStringValue(entry.Value);

					if (value != null) {
						switch (key) {
							case "localizedName":
							case "displayName":
								this.Name = value;
								break;

							case "shortName":
								this.ShortName = value;
								break;

							case "info":
								this.Info = value;
								break;

							case "update_id":
								this.UpdateSlug = value;
								break;

							/*case "state": // Rendered invalid for now, TODO: figure out if state means more than just installed or not installed
								this.Installed = (value == "installed");
								break;*/

							case "version":
								this.Version = value;
								break;

							case "developerName":
								this.Developer = value;
								break;

							default: break;
						}
					}
				}
			}
		}


		protected virtual void ParseFlyable(Block block, FunctionCall function, IStatement origin) {
			if (function.Arguments.Count < 1) {
				throw new InvalidCastException();
			}

			IExpression arg0 = function.Arguments[0];
			string value = LuaHelper.GetExpressionStringValue(arg0);
			if (value != null) {
				this.AddFilesystemSlug(value);
			}
		}




		protected override void InitFromEntryFileBlock(Block block) {
			foreach (IStatement statement in block.Statements) {
				if (statement is FunctionCall functionCall) {
					Variable fn = (Variable)functionCall.Function;

					switch (fn.Name) {
						case "declare_plugin":
							ParsePluginDeclaration(block, functionCall, statement);
							break;

						case "make_flyable":
							this.ParseFlyable(block, functionCall, statement);
							break;
					}
				}
			}

			this.FinalizeInit();
		}


		internal override void FinalizeInit() {
			base.FinalizeInit();

			this.AddFilesystemSlugIfNone(this.GetPrimaryPathInfo().Slug);
			this.FilesystemSlugs = this.filesystemSlugs.ToArray();
		}




		public string PrettyFilesystemSlugs {
			get => string.Join(", ", this.FilesystemSlugs);
		}




		public string GetFirstFilesystemSlug() {
			if (this.FilesystemSlugs.Length < 1) {
				return null;
			}

			return this.FilesystemSlugs[0];
		}

		public string GetShortName()
			=> this.ShortName ?? this.GetFirstFilesystemSlug();

		public string GetName()
			=> this.Name ?? this.GetShortName();




		private IList<string> filesystemSlugs = new List<string>();

		internal void AddFilesystemSlug(string slug)
			=> this.filesystemSlugs.Add(slug);

		internal void AddFilesystemSlugIfNone(string slug) {
			if (this.filesystemSlugs.Count > 0) {
				return;
			}

			this.AddFilesystemSlug(slug);
		}




		public IEnumerable<Livery> GetLiveries(LiveryDirectory directory, int slugIndex)
			=> directory.GetLiveries(this, slugIndex);

		public IEnumerable<Livery> GetLiveries(StateDirectory directory, int slugIndex)
			=> this.GetLiveries(directory.Liveries, slugIndex);

		public IEnumerable<Livery> GetLiveries(LiveryDirectory directory) {
			for (int i = this.FilesystemSlugs.Length; i-- > 0;) {
				foreach (Livery livery in this.GetLiveries(directory, i)) {
					yield return livery;
				}
			}
		}

		public IEnumerable<Livery> GetLiveries(StateDirectory directory)
			=> this.GetLiveries(directory.Liveries);

		public IEnumerable<Livery> GetLiveries(DSMContext context)
			=> this.GetLiveries(context.StateDirectory);




		protected virtual Image GetIcon() {
			PluginPathInfo path = this.GetPrimaryPathInfo();

			foreach (string iconpath in IconPaths) {
				try {
					using (Stream stream = path.GetFileStream(iconpath)) {
						if (stream == null) {
							continue;
						}

						return Image.FromStream(stream);
					}
				} catch { }
			}

			return null;
		}




		public override string ToString() {
			return $"{this.GetType().Name} ({this.Name})";
		}

	}

}
