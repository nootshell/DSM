using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.API.Extensions;
using DSM.API.Installables.Modules;
using DSM.API.Utilities;




namespace DSM.API.Directories {

	public class StateDirectory : AbstractDirectory {

		public StateDirectory(string path) : base(path) { }




		private static readonly string[] ModuleFolders = new string[] {
			"Mods"
		};

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
			foreach (string directory in Directory.GetDirectories(path)) {
				if (!File.Exists($"{directory}/entry.lua")) {
					continue;
				}

				module = null;
				try {
					module = new TModule();
					module.ctor(directory);
				} catch (Relua.ParserException) {
					Console.WriteLine($"Parser exception in {directory}");
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
