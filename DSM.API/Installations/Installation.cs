using System;
using System.Collections.Generic;
using System.IO;

using DSM.API.Extensions;
using DSM.API.Modules;

using Relua;




namespace DSM.API.Installations {

	public partial class Installation {

		public string Path { get; set; }
		public InstallationType Type { get; set; }




		public Installation(InstallationType type, string path) : base() {
			this.Type = type;
			this.Path = path?.Replace("\\", "/");
		}




		public IEnumerable<TModule> GetModules<TModule>(string subdir) where TModule : Module, new() {
			ModuleCategoryAttribute attr = typeof(TModule).GetAttribute<ModuleCategoryAttribute>(false);
			if (attr == null) {
				throw new InvalidOperationException();
			}

			string path = $"{this.Path}/{subdir}/{attr.Category}";
			if (!Directory.Exists(path)) {
				yield break;
			}

			TModule module;
			foreach (string file in Directory.GetDirectories(path)) {
				if (!File.Exists($"{file}/entry.lua")) {
					continue;
				}

				module = null;
				try {
					module = Module.FromPluginFile<TModule>($"{file}/entry.lua");
				} catch (ParserException) {
					Console.WriteLine($"Parser exception in {file}");
					continue;
				}

				if (module != null) {
					yield return module;
				}
			}
		}

		public IEnumerable<TModule> GetModules<TModule>() where TModule : Module, new() {
			foreach (string subdir in ModuleFolders) {
				foreach (TModule module in this.GetModules<TModule>(subdir)) {
					yield return module;
				}
			}
		}

	}

}
