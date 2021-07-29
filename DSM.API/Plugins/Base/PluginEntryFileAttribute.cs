using System;




namespace DSM.API.Plugins.Base {

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class PluginEntryFileAttribute : Attribute {

		public string EntryFile { get; set; }


		public PluginEntryFileAttribute(string entryfile) : base() {
			this.EntryFile = entryfile;
		}

	}

}
