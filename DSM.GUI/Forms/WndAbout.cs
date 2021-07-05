using System;
using System.Drawing;
using System.Windows.Forms;

using DSM.GUI.Utilities;




namespace DSM.GUI.Forms {

	public partial class WndAbout : Form {

		public WndAbout() {
			this.InitializeComponent();
			this.Icon = Properties.Resources.IconAbout;
			this.lblTitle.Text = Strings.TITLE;

			string authors = "";
			foreach (Tuple<string, DateTime, DateTime?> tuple in Strings.Authors) {
				authors += $"{tuple.Item1}: {Humanize.Datetime(tuple.Item2)} - {Humanize.Datetime(tuple.Item3)}\n";
			}

			this.lblAuthorsValue.Text = authors;
			this.lblAuthorsValue.Invalidate();

			/* To autosize the window based on the authors list, in case that ever becomes bigger. */
			this.ClientSize = new Size(
				this.ClientSize.Width,
				this.ClientSize.Height + (this.lblAuthorsValue.Height - this.lblAuthors.Height)
			);
		}

		private void OnLinkLabel_ProcessStart(object sender, LinkLabelLinkClickedEventArgs e)
			=> DefaultEvents.OnLinkClicked_Open(sender, e);

	}

}
