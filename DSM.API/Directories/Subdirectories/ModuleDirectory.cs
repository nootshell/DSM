using DSM.API.Extensions;
using DSM.API.Installables.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DSM.API.Directories.Subdirectories {

	public class ModuleDirectory : AbstractSubdirectory {

		public ModuleDirectory(AbstractDirectory parentDirectory, string subdir) : base(parentDirectory, subdir) { }




		public IEnumerable<TModule> GetModules<TModule>() where TModule : Module, new() {
			ModuleCategoryAttribute attr = typeof(TModule).GetAttribute<ModuleCategoryAttribute>(false);
			if (attr == null) {
				throw new InvalidOperationException();
			}

			string path = $"{this.Path}/{attr.Category}";
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

	}
}
