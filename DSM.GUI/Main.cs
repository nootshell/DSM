using System;
using System.Windows.Forms;

using DSM.GUI.Forms;




namespace DSM.GUI {

	internal static class Program {

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			WndLoad loadscreen = new WndLoad();
			Application.Run(loadscreen);

			if (loadscreen.Satisfied) {
				Application.Run(new Forms.WndMain() { Context = loadscreen.Context });
			}
		}

	}

}
