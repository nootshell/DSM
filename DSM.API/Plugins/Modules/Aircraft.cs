using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Relua;
using Relua.AST;




namespace DSM.API.Plugins.Modules {

	[ModuleCategory("aircraft")]
	public class Aircraft : Module {

		public Aircraft() : base() { }
		public Aircraft(string path, bool installed) : base(path, installed) { }

	}

}
