using DSM.API.Plugins;
using DSM.API.Plugins.Base;
using DSM.API.Plugins.Modules;
using DSM.API.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.API.Directories.Subdirectories {
	public class LiveryDirectory : AbstractSubdirectory {

		public LiveryDirectory(AbstractDirectory parentDirectory, string subdir) : base(parentDirectory, subdir) { }




		public IEnumerable<Livery> GetLiveries(string subdir) {
			string path_fs = Normalize.FilesystemPath($"{this.Path}/{subdir}");

			if (!Directory.Exists(path_fs)) {
				yield break;
			}

			foreach (string file in Directory.EnumerateFiles(path_fs, "*.zip", SearchOption.TopDirectoryOnly)) {
				yield return new Livery(file, true);
			}

			string entry = Plugin.GetEntryFile<Livery>();
			string path_plugin;
			foreach (string dir in Directory.GetDirectories(path_fs)) {
				path_plugin = Normalize.FilesystemPath($"{dir}/{entry}");
				if (!File.Exists(Normalize.FilesystemPath(path_plugin))) {
					continue;
				}

				yield return new Livery(dir, true);
			}
		}

		public IEnumerable<Livery> GetLiveries(string[] subdirs) {
			foreach (string subdir in subdirs) {
				foreach (Livery livery in this.GetLiveries(subdir)) {
					yield return livery;
				}
			}
		}

		public IEnumerable<Livery> GetLiveries(Module module, int slugIndex) {
			string slug = module.FilesystemSlugs[slugIndex];

			return this.GetLiveries(slug);
		}

	}
}
