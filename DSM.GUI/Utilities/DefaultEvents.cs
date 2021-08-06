using System.Diagnostics;
using System.IO;
using System.Windows.Forms;




namespace DSM.GUI.Utilities {

	public static class DefaultEvents {

		public static string GetLinkText(LinkLabel label) {
			return label.Text.Substring(label.LinkArea.Start, label.LinkArea.Length);
		}

		public static void ShellStart(string target) {
			_ = Process.Start(new ProcessStartInfo(target) { UseShellExecute = true });
		}

		public static void ExploreFolder(string target) {
			if (!Directory.Exists(target)) {
				// TODO: error
				return;
			}

			ShellStart(target);
		}


		public static void OnLinkClicked_Open(object sender, LinkLabelLinkClickedEventArgs e) {
			ShellStart(GetLinkText(sender as LinkLabel));
		}

		public static void OnLinkClicked_OpenFolder(object sender, LinkLabelLinkClickedEventArgs e) {
			ExploreFolder(GetLinkText(sender as LinkLabel));
		}

	}

}
