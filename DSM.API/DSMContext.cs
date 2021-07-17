using System;

using DSM.API.Directories;
using DSM.API.Directories.Managers;




namespace DSM.API {

	public class DSMContext {

		public InstallationDirectoryManager InstallationDirectoryManager { get; protected set; }
		public StateDirectoryManager StateDirectoryManager { get; protected set; }

		public InstallationDirectory Installation { get; set;  }
		public StateDirectory State { get; set; }




		public DSMContext() : base() {
			this.InstallationDirectoryManager = new InstallationDirectoryManager();
			this.StateDirectoryManager = new StateDirectoryManager($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Saved Games");

			this.Installation = this.InstallationDirectoryManager.GetPrimaryInstallationDirectory();
			this.State = this.StateDirectoryManager.GetPrimaryStateDirectory();
		}

	}

}




/*

TODO: module -> info
                liveries
                countermeasures

      tracks -> info
                archive
                clean

      diagnostics -> analyze

 */
