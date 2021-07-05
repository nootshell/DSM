using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.Win32;




namespace DSM.API.Installations {

	partial class Installation {

		private static readonly string[] ModuleFolders = new string[] {
			//"CoreMods", // not supporting coremods for now, adds confusion. may be reintroduced when i can make a clear distinction between full and half fidelity modules.
			"Mods"
		};

		private static readonly string RetailChannelFile = "Config/retail.cfg";

		private static readonly Dictionary<string, InstallationType> RetailChannels = new Dictionary<string, InstallationType>(StringComparer.OrdinalIgnoreCase) {
			{ "ED", InstallationType.Standalone },
			{ "STEAM", InstallationType.Steam }
		};

		private static readonly string[] VerifyFilePaths = new string[] {
			RetailChannelFile,

			"dcs_manifest.bin",
			"bin/DCS.exe",
			"MissionEditor/MissionEditor.lua"
		};

		private static readonly SortedDictionary<InstallationType, string> TypeHomepages = new SortedDictionary<InstallationType, string>() {
			{ InstallationType.Standalone, "https://www.digitalcombatsimulator.com/" },
			{ InstallationType.Steam, "https://steamcommunity.com/app/223750" }
		};




		public static Installation Detected { get; private set; }




		public static InstallationType VerifyInstallation(string path) {
			foreach (string file in VerifyFilePaths) {
				if (!File.Exists($"{path}/{file}")) {
					return InstallationType.Unknown;
				}
			}

			using (FileStream stream = File.OpenRead($"{path}/{RetailChannelFile}")) {
				using (StreamReader reader = new StreamReader(stream)) {
					if (RetailChannels.TryGetValue(reader.ReadLine()?.Trim(), out InstallationType type)) {
						return type;
					}
				}
			}

			return InstallationType.Unknown;
		}




		public static bool DetectInstallation_WinReg_Standalone(out InstallationType type, out string path) {
			using (RegistryKey k_standalone = Registry.CurrentUser.OpenSubKey(@"Software\Eagle Dynamics")) {
				if (k_standalone == null) {
					goto fail_bad;
				}

				string p;
				foreach (string k in k_standalone.GetSubKeyNames().Where(k => k.StartsWith("DCS World"))) {
					if (k.Contains("Server")) {
						// not supporting server instances for now
						continue;
					}

					using (RegistryKey k_install = k_standalone.OpenSubKey(k)) {
						if (k_install == null) {
							continue;
						}

						p = (string)k_install.GetValue("Path");
						type = VerifyInstallation(p);
						if (type != InstallationType.Unknown) {
							path = p;
							return true;
						}
					}
				}
			}

fail_bad:
			type = InstallationType.Unknown;
			path = null;
			return false;
		}


		public static bool DetectInstallation_WinReg_Steam(out InstallationType type, out string path) {
			using (RegistryKey k_steam = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 223750")) {
				if (k_steam == null) {
					goto fail_bad;
				}

				string p = (string)k_steam.GetValue("InstallLocation");
				type = VerifyInstallation(p);
				if (type != InstallationType.Unknown) {
					path = p;
					return true;
				}
			}

fail_bad:
			type = InstallationType.Unknown;
			path = null;
			return false;
		}


		public static bool DetectInstallation_WinReg(out InstallationType type, out string path) {
			if (DetectInstallation_WinReg_Standalone(out type, out path)) {
				return true;
			}

			if (DetectInstallation_WinReg_Steam(out type, out path)) {
				return true;
			}

			type = InstallationType.Unknown;
			path = null;
			return false;
		}




		public static bool DetectInstallation(string hint) {
			if (hint != null) {
				InstallationType type_hinted = VerifyInstallation(hint);
				if (type_hinted != InstallationType.Unknown) {
					Detected = new Installation(type_hinted, hint);
					return true;
				}
			}

			if (DetectInstallation_WinReg(out InstallationType type_winreg, out string path)) {
				Detected = new Installation(type_winreg, path);
				return true;
			}

			Detected = null;
			return false;
		}

		public static bool DetectInstallation()
			=> DetectInstallation(null);





		public static string GetTypeHomepage(InstallationType type) {
			if (TypeHomepages.TryGetValue(type, out string homepage)) {
				return homepage;
			}

			return null;
		}

	}

}
