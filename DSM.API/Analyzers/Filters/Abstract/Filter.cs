using DSM.API.Analyzers.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace DSM.API.Analyzers.Filters.Abstract {

	public abstract class Filter {

		public const RegexOptions DEFAULT_OPTIONS = (RegexOptions.Compiled | RegexOptions.IgnoreCase);

		protected RegexOptions regex_options = DEFAULT_OPTIONS;
		protected IList<string> patterns = new List<string>();

		public Severity? OnSeverity { get; set; }



		public Filter() : base() {
			Debug.WriteLine($"Loaded filter: {this.GetType().Name}");
		}

		public Filter(Severity? onSeverity, params string[] patterns) : this() {
			this.OnSeverity = onSeverity;

			if (patterns?.Length > 0) {
				foreach (string pattern in patterns) {
					this.AddPattern(pattern);
				}
			}
		}




		protected virtual void Setup() { }




		protected void AddPattern(string pattern) {
			IEqualityComparer<string> comparer = StringComparer.Ordinal;
			if (this.regex_options.HasFlag(RegexOptions.IgnoreCase)) {
				comparer = StringComparer.OrdinalIgnoreCase;
			}

			if (this.patterns.Contains(pattern, comparer)) {
				return;
			}

			this.patterns.Add(pattern);
		}



		public IEnumerable<string> GetPatterns()
			=> this.patterns;

		public IEnumerable<Match> GetMatches(string input) {
			MatchCollection matches;
			foreach (string pattern in this.GetPatterns()) {
				matches = Regex.Matches(input, pattern, this.regex_options);
				if (matches.Count < 1) {
					continue;
				}

				foreach (Match match in matches) {
					if (!match.Success) {
						continue;
					}

					yield return match;
				}
			}
		}



		protected abstract void ProcessLineMatch(Analyzer analyzer, string line, Match match);

		public virtual IEnumerable<Match> ProcessLine(Analyzer analyzer, Severity severity, string line) {
			if (this.OnSeverity != null && this.OnSeverity != severity) {
				yield break;
			}

			foreach (Match match in this.GetMatches(line)) {
				this.ProcessLineMatch(analyzer, line, match);
				yield return match;
			}
		}

	}

}
