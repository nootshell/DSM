using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.API.Extensions;
using DSM.API.Modules;
using DSM.API.Parsers;
using DSM.API.Utilities;
using Relua;

namespace DSM.API.Directories {

	public class InstallationDirectory : AbstractDirectory {

		public enum DirectoryType {
			Unknown = 0,
			Standalone = 1,
			Steam = 2
		}




		public DirectoryType Type { get; set; }


		private static readonly SortedDictionary<DirectoryType, string> TypeHomepages = new SortedDictionary<DirectoryType, string>() {
			{ DirectoryType.Standalone, "https://www.digitalcombatsimulator.com/" },
			{ DirectoryType.Steam, "https://steamcommunity.com/app/223750" }
		};

		public string Homepage { get => (TypeHomepages.ContainsKey(this.Type) ? TypeHomepages[this.Type] : null); }




		public InstallationDirectory(DirectoryType type, string path) : base(path) {
			this.Type = type;
		}




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
			foreach (string file in Directory.GetDirectories(path)) {
				if (!File.Exists($"{file}/entry.lua")) {
					continue;
				}

				module = null;
				try {
					module = (new PluginFileParser($"{file}/entry.lua")).Parse<TModule>();
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
