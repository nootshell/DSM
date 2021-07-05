using System;

using DSM.API.Installations;




namespace DSM.API {

	public class DSMContext {

		public Installation Installation { get; protected set; }
		public string[] Variants { get; protected set; }




		public DSMContext() : base() {
			if (!this.DetectInstallation()) {
				throw new NotImplementedException();
			}

			this.Installation = Installation.Detected;
		}




		public bool DetectInstallation()
			=> Installation.DetectInstallation();

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
