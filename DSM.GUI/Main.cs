using System;
using System.Windows.Forms;

using DSM.API.Installations;
using DSM.GUI.Forms;




namespace DSM.GUI {

	internal static class Program {

		static bool HaveRequirements => ((Installation.Detected?.Type ?? InstallationType.Unknown) != InstallationType.Unknown);

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			WndLoad entry = new WndLoad();
			Application.Run(entry);

			if (HaveRequirements) {
				Application.Run(new Forms.WndMain() { Context = entry.Context });
			}
		}

	}

}
