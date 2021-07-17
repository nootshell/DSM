using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using DSM.API.Utilities;




namespace DSM.API.Directories.Managers {

	public partial class StateDirectoryManager : AbstractDirectoryManager<StateDirectory> {

		public string StateRootPath { get; set; }




		public StateDirectoryManager(string root) : base() {
			this.StateRootPath = root;
		}




		public IEnumerable<StateDirectory> GetStateDirectories() {
			foreach (string path in Directory.EnumerateDirectories(this.StateRootPath, "DCS*", SearchOption.TopDirectoryOnly)) {
			    if (!VerifyStateDirectory(path)) {
			            continue;
			    }

				yield return (this.GetCachedInstance(path) ?? this.SetCachedInstance(path, new StateDirectory(path)));
			}
		}




		public StateDirectory GetPrimaryStateDirectory()
			=> this.GetStateDirectories().FirstOrDefault();




		#region Static

		private static readonly string[] VerifyStatePaths = new string[] {
			"Config/options.lua"
		};

		public static bool VerifyStateDirectory(string path) {
			foreach (string file in VerifyStatePaths) {
				if (!File.Exists($"{path}/{file}")) {
					return false;
				}
			}

			return true;
		}

		#endregion

	}

}
