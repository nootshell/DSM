using DSM.API.Utilities;
using Relua.AST;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSM.API.Installables {

	public class Livery : Installable {

		public override string LuaFile => "description.lua";




		public Livery(string path) : base(path) { }




		protected override void InitFromLuaBlock(Block block) {
			this.Name = LuaHelper.GetExpressionStringValue(LuaHelper.FindVariableValue(block, "name", null, null));
		}

	}

}
