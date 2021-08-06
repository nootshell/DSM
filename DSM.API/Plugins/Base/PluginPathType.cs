using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.API.Plugins.Base {

	public enum PluginPathType {
		Unknown = 0,
		Auto = 1,

		[Description(nameof(Directory))]
		Directory = 2,

		[Description("Archive (zip)")]
		ZipArchive = 3
	}

}
