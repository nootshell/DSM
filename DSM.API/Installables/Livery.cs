using DSM.API.Utilities;
using Relua.AST;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSM.API.Installables {

	public class Livery : Installable {

		public const string PLUGIN = "description.lua";
		public override string LuaFile => PLUGIN;




		public Livery() : base() { }
		public Livery(string path) : base(path) { }




		protected override void InitFromLuaBlock(Block block) {
			this.Name = LuaHelper.GetExpressionStringValue(LuaHelper.FindVariableValue(block, "name", null, null));
		}

	}

}
