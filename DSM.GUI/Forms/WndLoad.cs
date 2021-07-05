using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using DSM.API;
using DSM.API.Installations;




namespace DSM.GUI.Forms {

	public partial class WndLoad : Form, IDisposable {

		public DSMContext Context { get; protected set; }




		private Task load = null;

		public WndLoad() {
			this.InitializeComponent();
			this.Icon = Properties.Resources.Icon;
			this.Text = Strings.TITLE;

			this.load = this.DoLoad();
		}




		protected async Task DoLoad() {
			if (!Installation.DetectInstallation()) {
				_ = MessageBox.Show(this, "Couldn't find the DCS installation.");
				Application.Exit();
			}

			if (!StateManager.FindStateRootPath()) {
				// error
			}

			if (!StateManager.FindExistingVariants()) {
				// error
			}

			await Task.Delay(5);
		}



		protected override async void OnShown(EventArgs e) {
			base.OnShown(e);

			await Task.Delay(650);
			await this.load;

			this.Context = new DSMContext();
			this.Close();
		}

	}

}
