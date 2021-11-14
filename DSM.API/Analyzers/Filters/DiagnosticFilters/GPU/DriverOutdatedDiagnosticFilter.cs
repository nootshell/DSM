using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.API.Analyzers.Filters.DiagnosticFilters.GPU {

	public class DriverOutdatedDiagnosticFilter : Abstract.DiagnosticFilter {

		static readonly string[] Patterns = new string[] {
			"DX11BACKEND: texture (?<missing_texture>.+) not found. Asked from (?<missing_texture_source>.+)$",
			"DX11BACKEND: render target (?<missing_render_target>.+) not found"
		};

		public DriverOutdatedDiagnosticFilter() : base(Severity.Error, Patterns) { }

	}

}
