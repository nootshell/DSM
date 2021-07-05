using System;
using System.Collections.Generic;
using System.IO;




namespace DSM.API {

	public class StateManager {

		private static readonly string[] VerifyStatePaths = new string[] {
			"Config/options.lua"
		};

		public static string StateRootPath { get; set; }
		public static string[] ExistingVariants { get; set; }




		public static bool FindStateRootPath() {
			string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Saved Games";

			if (!Directory.Exists(path)) {
				return false;
			}

			StateRootPath = path;
			return true;
		}




		public static bool VerifyStateDirectory(string path) {
			foreach (string file in VerifyStatePaths) {
				if (!File.Exists($"{path}/{file}")) {
					return false;
				}
			}

			return true;
		}




		// TODO: turn this into something more dynamic/reactive (e.g. VariantCollection that monitors filesystem)
		public static bool FindExistingVariants() {
			List<string> variants = new List<string>();

			string v;
			foreach (string variantDir in Directory.EnumerateDirectories(StateRootPath, "DCS*", SearchOption.TopDirectoryOnly)) {
				if (!VerifyStateDirectory(variantDir)) {
					continue;
				}

				v = variantDir.Replace("\\", "/");
				v = v.Substring(v.LastIndexOf("/") + 1);
				variants.Add(v);
			}

			ExistingVariants = variants.ToArray();

			return (ExistingVariants?.Length > 0);
		}






		/// <summary>
		/// The path of the state folder we're managing relative to <see cref="RootDirectory"/>. Usually DCS or DCS.openbeta.
		/// </summary>
		public string RelativePath { get; set; }

	}

}
