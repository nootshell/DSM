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

	public class InstallationDirectory : StateDirectory {

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

	}
	
}
