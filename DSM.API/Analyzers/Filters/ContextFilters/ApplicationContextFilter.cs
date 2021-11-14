namespace DSM.API.Analyzers.Filters.ContextFilters {

	public class ApplicationContextFilter : Abstract.ContextFilter {

		static readonly string[] Patterns = new string[] {
			"APP: Command line: (?<commandline>.+)$",
			"APP: DCS/(?<version>[0-9]+(?:.[0-9]+){3}) \\((?<architecture>[^;]+); (?<platform>[^)]+)\\)$",
			"Dispatcher: (?<dispatcher>[0-9/ :-]+ V[0-9]+)$",
			"APP: (?<key>(?:Application|Renderer|Terrain|Build) (?:revision|number)): (?<value>[0-9]+)$"
		};

		public ApplicationContextFilter(Severity? onSeverity) : base(onSeverity, Patterns) { }

	}

}
