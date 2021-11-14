using DSM.API.Analyzers.Filters.Abstract;
using DSM.API.Analyzers.Primitives;
using DSM.API.Extensions;
using DSM.API.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace DSM.API.Analyzers.Abstract {

	public abstract class Analyzer {

		protected List<Filter> filters = new List<Filter>();
		protected Dictionary<string, object> context = new Dictionary<string, object>();




		protected Analyzer() : base() { }




		protected string NormalizeContextKey(string key) {
			key = key.ToLower();
			key = Regex.Replace(key, "\\s", "_");
			key = Regex.Replace(key, "[^a-z0-9_]", "");
			return key;
		}


		protected object NormalizeContextValue(object value) {
			if (value is string s_value) {
				/* Strip quotes. */
				Match match = Regex.Match(s_value, "^[\"']+(?<value>[^\"']+)[\"']+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
				if (match.Success) {
					s_value = match.Groups["value"].Value.Trim();
				}

				/* Null if considered empty. */
				if (string.IsNullOrWhiteSpace(s_value)) {
					s_value = null;
				}

				value = s_value;
			}

			return value;
		}


		public void AddContext(string key, object value) {
			key = this.NormalizeContextKey(key);
			value = this.NormalizeContextValue(value);

			if (value == null) {
				return;
			}

			if (!this.context.ContainsKey(key)) {
				this.context[key] = value;
				return;
			}

			object current = this.context[key];

			if (current.Equals(value)) {
				return;
			}

			if (current is IList<object> as_list) {
				if (!as_list.Contains(value)) {
					as_list.Add(value);
				}
				return;
			}

			this.context[key] = new List<object>() { current, value };
		}




		protected virtual void ProcessLine(DateTime timestamp, Severity severity, string line) {
			List<Range<int>> mark_ranges = new List<Range<int>>();

			bool is_kvp;
			Group group;
			foreach (Filter filter in this.filters.Where(x => x.OnSeverity == null || x.OnSeverity == severity)) {
				foreach (Match match in filter.ProcessLine(this, severity, line)) {
					is_kvp = (match.Groups.Count == (2 + 1) && !string.IsNullOrEmpty(match.Groups["key"].Value) && !string.IsNullOrEmpty(match.Groups["value"].Value));

					for (int i = 1, start, end; i < match.Groups.Count; ++i) {
						group = match.Groups[i];
						if (is_kvp && group.Name == "key") {
							continue;
						}

						start = group.Index;
						end = (start + group.Length);
						mark_ranges.Add(new Range<int>(start, end) { Tag = filter });
					}
				}
			}

			string s_ranges = "";
			int n_ranges = mark_ranges.Count, color;
			if (n_ranges > 0) {
				s_ranges = $" \x1B[90m({Humanize.PluralizedString(n_ranges, "match", "matches")})\x1B[0m";

				foreach (Range<int> range in mark_ranges.Collapse().OrderByDescending(x => x.Start)) {
					color = 9;
					if (range.Tag != null) {
						Type type = range.Tag.GetType();

						if (type.IsSubclassOf(typeof(ContextFilter))) {
							color = 7;
						} else if (type.IsSubclassOf(typeof(DiagnosticFilter))) {
							color = 1;
						}

						Debug.WriteLine($"{range.Start} {range.Tag} {type.Name} {color}");
					}

					line = line.Insert(range.End, "\x1B[0m");
					line = line.Insert(range.Start, $"\x1B[9{color};1;4m");
				}
			}

			Console.WriteLine($"{timestamp} {severity} {line}{s_ranges}");
		}


		protected abstract bool CheckLineHasStart(string line);
		protected abstract void ProcessRawLine(string line);




		protected string line = null;

		protected virtual void ConsumeLine(string line) {
			bool has_start = this.CheckLineHasStart(line);

			if (this.line == null) {
				if (!has_start) {
					Console.WriteLine($"Ignored: {line}");
					return;
				}

				this.line = line;
				return;
			}

			if (has_start) {
				this.ProcessRawLine(this.line);
				this.line = line;
			} else {
				this.line += $"\n{line}";
			}
		}

	}

}
