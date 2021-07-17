using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DSM.API.Utilities;




namespace DSM.API.Directories {
	public abstract class AbstractDirectory {

		public string Path { get; set; }

		public string Name {
			get {
				string p = Normalize.ProcessableFilesystemPath(this.Path);
				return p.Substring(p.LastIndexOf("/") + 1);
			}
		}




		private AbstractDirectory() : base() { }

		protected AbstractDirectory(string path) : this() {
			if (!Directory.Exists(path)) {
				throw new ArgumentException("The specified path must refer to an existing directory.");
			}
			this.Path = Normalize.FilesystemPath(path);
		}

	}
}
