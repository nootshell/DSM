using DSM.API.Plugins.Base;
using DSM.API.Utilities;
using Relua.AST;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DSM.API.Plugins {

	[PluginEntryFile("description.lua")]
	public class Livery : Plugin {

		public string Name { get; set; }




		public Livery(string path, bool installed) : base(path, installed) { }




		protected override void InitFromEntryFileBlock(Block block) {
			this.Name = LuaHelper.GetExpressionStringValue(LuaHelper.FindVariableValue(block, "name", null, null));
		}

	}

}
