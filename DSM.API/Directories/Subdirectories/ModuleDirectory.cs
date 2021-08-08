using DSM.API.Extensions;
using DSM.API.Plugins.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DSM.API.Directories.Subdirectories {

	public class ModuleDirectory : AbstractSubdirectory {

		public ModuleDirectory(AbstractDirectory parentDirectory, string subdir) : base(parentDirectory, subdir) { }




		public IEnumerable<Module> GetModules(Type tmodule) {
			ModuleCategoryAttribute attr = tmodule.GetAttribute<ModuleCategoryAttribute>(false);
			if (attr == null) {
				throw new InvalidOperationException();
			}

			string path = $"{this.Path}/{attr.Category}";
			if (!Directory.Exists(path)) {
				yield break;
			}

			Module module;
			foreach (string directory in Directory.GetDirectories(path)) {
				if (!File.Exists($"{directory}/entry.lua")) {
					continue;
				}

				module = null;
				try {
					module = (Module)Activator.CreateInstance(tmodule);
					module.Init(directory, true);
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
			foreach (Module module in this.GetModules(typeof(TModule))) {
				yield return (TModule)module;
			}
		}

	}
}
