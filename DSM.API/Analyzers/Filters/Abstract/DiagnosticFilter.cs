using DSM.API.Analyzers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DSM.API.Analyzers.Filters.Abstract {

	public abstract class DiagnosticFilter : Filter {

		public DiagnosticFilter(Severity? onSeverity, params string[] patterns) : base(onSeverity, patterns) { }



		protected override void ProcessLineMatch(Analyzer analyzer, string line, Match match) {
			// TODO
		}

	}

}
