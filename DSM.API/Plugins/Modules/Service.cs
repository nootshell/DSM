namespace DSM.API.Plugins.Modules {

	[ModuleCategory("services")]
	public class Service : Module {

		public Service() : base() { }
		public Service(string path, bool installed) : base(path, installed) { }

	}

}
