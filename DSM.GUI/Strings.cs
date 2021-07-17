using System;




namespace DSM.GUI {

	internal class Strings {

		internal const string TITLE = "DCS State Manager";
		internal const string CORE = "Core";
		internal const string MODS = "Mods";
		internal const string DEFAULT_VARIANT = "DCS";
		internal const string OPEN_INSTALLDIR_IN_EXPLORER = "Open the installation directory in your file explorer.";
		internal const string USE_UNVERIFIED_FOLDER = "The specified folder could not be verified, do you still want to use it?";
		internal const string WARNING = "Warning";

		internal static readonly Tuple<string, DateTime, DateTime?>[] Authors = new Tuple<string, DateTime, DateTime?>[] {
			new Tuple<string, DateTime, DateTime?>("Solen'ya | Nootshell", new DateTime(2021, 07, 01), null)
		};

	}

}
