using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using DSM.API;




namespace DSM.GUI.Forms {

	public partial class WndLoad : Form, IDisposable {

		public DSMContext Context { get; protected set; }
		public bool Satisfied { get; protected set; }




		private Task load = null;

		public WndLoad() {
			this.InitializeComponent();
			this.Icon = Properties.Resources.Icon;
			this.Text = Strings.TITLE;

			this.load = this.DoLoad();
		}




		protected async Task DoLoad() {
			this.Context = new DSMContext();

			this.Satisfied = true;

			if (!this.Context.InstallationDirectoryManager.AnyDetected) {
				this.Satisfied = false;
				_ = MessageBox.Show(this, "Couldn't find the DCS installation.");
				Application.Exit();
			}

			// TODO: states

			await Task.Delay(5);
		}



		protected override async void OnShown(EventArgs e) {
			base.OnShown(e);

			await Task.Delay(650);
			await this.load;

			this.Close();
		}

	}

}
