namespace DSM.API.Analyzers.Filters.ContextFilters {

	public class NetworkingContextFilter : Abstract.ContextFilter {

		static readonly string[] Patterns = new string[] {
			"NET: ProtocolVersion: (?<net_proto>[0-9]+)$"
		};

		public NetworkingContextFilter(Severity? onSeverity) : base(onSeverity, Patterns) { }

	}

}
