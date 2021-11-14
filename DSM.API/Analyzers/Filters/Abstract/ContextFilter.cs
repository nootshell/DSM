using DSM.API.Analyzers.Abstract;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DSM.API.Analyzers.Filters.Abstract {

	public abstract class ContextFilter : Filter {

		public ContextFilter() : base() { }
		public ContextFilter(Severity? onSeverity, params string[] patterns) : base(onSeverity, patterns) { }




		protected virtual void AddContext(Analyzer analyzer, string key, string value) {
			Debug.WriteLine($"{this.GetType().Name} SetContext {key}={value}");
			analyzer.AddContext(key, value);
		}




		protected override void ProcessLineMatch(Analyzer analyzer, string line, Match match) {
			/* Edge case for patterns with a named key group and a named value group. */
			if (match.Groups.Count == (2 + 1)) {
				string key = match.Groups["key"].Value, value = match.Groups["value"].Value;

				if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value)) {
					this.AddContext(analyzer, key, value);
					return;
				}
			}

			foreach (Group group in match.Groups) {
				/* Filter out the whole input match. */
				if (group.Name == "0") {
					continue;
				}

				this.AddContext(analyzer, group.Name, group.Value);
			}
		}

	}

}
