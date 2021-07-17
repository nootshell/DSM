using DSM.API.Utilities;
using Relua;
using Relua.AST;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DSM.API.Installables {

	public abstract class Installable {

		public string Name { get; set; }
		public string Path { get; set; }

		public abstract string LuaFile { get; }

		public string PathSlug { get => SlugHelper.GetSlug(this.Path); }




		public Installable() : base() { }

		public Installable(string path) : this() {
			this.ctor(path);
		}

		internal void ctor(string path) {
			string path_fs = Normalize.FilesystemPath(path);
			this.Path = path_fs;

			using (FileStream stream = File.OpenRead(Normalize.FilesystemPath($"{path_fs}/{this.LuaFile}"))) {
				using (StreamReader reader = new StreamReader(stream)) {
					this.InitFromLuaBlock((new Parser(reader)).Read());
				}
			}
		}



		protected abstract void InitFromLuaBlock(Block block);

	}

}
