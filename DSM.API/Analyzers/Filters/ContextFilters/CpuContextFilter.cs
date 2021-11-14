namespace DSM.API.Analyzers.Filters.ContextFilters {

	public class CpuContextFilter : Abstract.ContextFilter {

		static readonly string[] Patterns = new string[] {
			"APP: CPU cores: (?<cpu_cores>[0-9]+), threads: (?<cpu_threads>[0-9]+), system ram: (?<ram_phys>[0-9]+) (?<ram_phys_unit>[A-Z]+), pagefile: (?<ram_virt>[0-9]+) (?<ram_virt_unit>[A-Z]+)$"
		};

		public CpuContextFilter(Severity? onSeverity) : base(onSeverity, Patterns) { }

	}

}
