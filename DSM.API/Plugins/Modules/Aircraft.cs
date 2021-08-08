namespace DSM.API.Plugins.Modules {

	[ModuleCategory("aircraft")]
	public class Aircraft : Module, ILiveryConfigurableModule {

		public Aircraft() : base() { }
		public Aircraft(string path, bool installed) : base(path, installed) { }

	}

}
