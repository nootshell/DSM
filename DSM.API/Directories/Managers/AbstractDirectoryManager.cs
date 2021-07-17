using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.API.Utilities;
using Microsoft.Win32;




namespace DSM.API.Directories.Managers {

	public abstract class AbstractDirectoryManager<TDirectory> where TDirectory : AbstractDirectory {

		protected AbstractDirectoryManager() {

		}




		protected SortedDictionary<string, TDirectory> cache = new SortedDictionary<string, TDirectory>(StringComparer.OrdinalIgnoreCase);

		public TDirectory GetCachedInstance(string path) {
			if (!this.cache.ContainsKey(path)) {
				return null;
			}

			return this.cache[path];
		}

		public TDirectory SetCachedInstance(string path, TDirectory instance)
			=> this.cache[path] = instance;

	}

}
