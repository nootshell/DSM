using DSM.API.Analyzers.Abstract;
using System.Text.RegularExpressions;

namespace DSM.API.Analyzers.Filters.ContextFilters {

	public class PeripheralContextFilter : Abstract.ContextFilter {

		static readonly string[] Patterns = new string[] {
			"INPUT: (?<device_type>Device) \\[(?<device_name>[^\\]]+)\\] created.$",
			"INPUT: (?<device_type>Joystick) created\\s*\\[(?<device_name>[^\\]]+)\\], ForceFeedBack: (?<device_ffb>yes|no)$"
		};

		public PeripheralContextFilter(Severity? onSeverity) : base(onSeverity, Patterns) { }



		protected override void ProcessLineMatch(Analyzer analyzer, string line, Match match) {

		}

	}

}
