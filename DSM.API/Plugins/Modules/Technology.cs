namespace DSM.API.Plugins.Modules {

	[ModuleCategory("tech")]
	public class Technology : Module, ILiveryConfigurableModule {

		public Technology() : base() { }
		public Technology(string path, bool installed) : base(path, installed) { }

	}

}
