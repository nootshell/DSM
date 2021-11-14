using DSM.API.Analyzers.Filters.Abstract;
using DSM.API.Analyzers.Filters.ContextFilters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DSM.API.Analyzers {

	public class LogFileAnalyzer : Abstract.Analyzer {

		internal const bool DEFAULT_FOLLOW = false;

		protected bool follow = false;
		protected TextReader reader = null;




		protected LogFileAnalyzer() : base() {
			this.filters = new List<Filter>() {
				new ApplicationContextFilter(Severity.Info),
				new CpuContextFilter(Severity.Info),
				new GpuContextFilter(Severity.Info),
				new NetworkingContextFilter(Severity.Info),
				new PeripheralContextFilter(Severity.Info)
			};

			foreach (Type type in Assembly.GetAssembly(typeof(DiagnosticFilter)).GetTypes().Where(type => type.IsSubclassOf(typeof(DiagnosticFilter)))) {
				this.filters.Add((DiagnosticFilter)Activator.CreateInstance(type));
			}
		}

		public LogFileAnalyzer(TextReader reader, bool follow = DEFAULT_FOLLOW) : this() {
			this.reader = reader;
			this.follow = follow;
		}

		public LogFileAnalyzer(FileInfo file, bool follow = DEFAULT_FOLLOW) : this(file.OpenText(), follow) { }

		public LogFileAnalyzer(string path, bool follow = DEFAULT_FOLLOW) : this(new StreamReader(path), follow) { }




		const string pattern_timestamp = "[0-9]{4}(?:-[0-9]{2}){2} [0-9]{2}(?::[0-9]{2}){2}.[0-9]{3}";
		const string pattern_severity = "[A-Z_]{4,10}";
		static readonly Regex regex_prefix = new Regex($"^(?<timestamp>{pattern_timestamp}) (?<severity>{pattern_severity}) ", (RegexOptions.Compiled | RegexOptions.IgnoreCase));


		protected override bool CheckLineHasStart(string line)
			=> regex_prefix.IsMatch(line);


		protected override void ProcessRawLine(string line) {
			Match match = regex_prefix.Match(line);

			Severity severity = Severity.Unknown;
			string value = match.Groups["severity"].Value.ToLower();
			switch (value) {
				case "info":
					severity = Severity.Info;
					break;

				case "warning":
					severity = Severity.Warning;
					break;

				case "error_once":
				case "error":
					severity = Severity.Error;
					break;

				default:
					Console.WriteLine($"Unknown severity: {value}");
					break;
			}

			this.ProcessLine(
				DateTime.ParseExact(match.Groups["timestamp"].Value, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
				severity,
				line.Substring(match.Length).Trim()
			);
		}




		public void Analyze() {
			string line;
			while ((line = this.reader.ReadLine()) != null) {
				this.ConsumeLine(line);
			}
			;
		}

	}

}
