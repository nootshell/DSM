namespace DSM.API.Analyzers {

	/// <summary>
	/// Literal log line severity as declared by the writer.
	/// </summary>
	public enum Severity {
		Unknown = 0,

		Debug,
		Verbose,
		Info,
		Notice,
		Warning,
		Error,
		Critical
	}

}
