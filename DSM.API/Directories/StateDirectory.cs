using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.API.Directories.Subdirectories;
using DSM.API.Extensions;
using DSM.API.Plugins;
using DSM.API.Plugins.Modules;
using DSM.API.Utilities;




namespace DSM.API.Directories {

	public class StateDirectory : AbstractDirectory {

		public ModuleDirectory Mods { get; protected set; }
		public LiveryDirectory Liveries { get; protected set; }




		public StateDirectory(string path) : base(path) {
			this.Mods = new ModuleDirectory(this, nameof(this.Mods));
			this.Liveries = new LiveryDirectory(this, nameof(this.Liveries));
		}

	}

}
