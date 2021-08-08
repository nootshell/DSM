using DSM.API.Plugins.Base;
using DSM.API.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace DSM.GUI.Forms {

	public partial class WndInstall : Form {

		public Plugin Plugin { get; protected set; }




		public WndInstall(Plugin plugin) {
			this.InitializeComponent();

			this.Plugin = plugin;
		}

	}

}
