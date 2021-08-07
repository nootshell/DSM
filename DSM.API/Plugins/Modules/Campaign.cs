using System;
using System.Collections.Generic;
using System.Text;

namespace DSM.API.Plugins.Modules {

	[ModuleCategory("campaigns")]
	public class Campaign : Module {

		public Campaign() : base() { }
		public Campaign(string path, bool installed) : base(path, installed) { }

	}

}
