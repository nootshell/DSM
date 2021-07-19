using System;
using System.Linq;

using DSM.API.Directories;
using DSM.API.Directories.Managers;




namespace DSM.API {

	public class DSMContext {

		public InstallationDirectoryManager InstallationDirectoryManager { get; protected set; }
		public StateDirectoryManager StateDirectoryManager { get; protected set; }

		public InstallationDirectory InstallationDirectory { get; protected set; }
		public StateDirectory StateDirectory { get; protected set; }




		public delegate void StateDirectoryChangedHandler(DSMContext context, StateDirectory directory);
		public event StateDirectoryChangedHandler StateDirectoryChanged;




		public DSMContext() : base() {
			this.InstallationDirectoryManager = new InstallationDirectoryManager();
			this.StateDirectoryManager = new StateDirectoryManager($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Saved Games");

			this.InstallationDirectory = this.InstallationDirectoryManager.GetPrimaryInstallationDirectory();
			this.StateDirectory = this.StateDirectoryManager.GetPrimaryStateDirectory();
		}




		public bool SetStateDirectory(string name) {
			StateDirectory dir = this.StateDirectoryManager.GetStateDirectories().Where(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
			if (dir == null) {
				return false;
			}

			if (this.StateDirectory == dir) {
				return false;
			}

			this.StateDirectory = dir;
			this.StateDirectoryChanged?.Invoke(this, dir);
			return true;
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

      config -> backups (+ advisory to external storage)
                view/edit/copy?

      diagnostics -> analyze

 */
