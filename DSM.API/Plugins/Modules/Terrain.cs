using System;
using System.Collections.Generic;
using System.Text;

namespace DSM.API.Plugins.Modules {

	[ModuleCategory("terrains")]
	public class Terrain : Module {

		public Terrain() : base() { }
		public Terrain(string path, bool installed) : base(path, installed) { }

	}

}
