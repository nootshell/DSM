using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

using DSM.API.Utilities;
using System.IO;

namespace DSM.API.Directories.Managers {

	public partial class InstallationDirectoryManager : AbstractDirectoryManager<InstallationDirectory> {

		public bool UseRegistry { get; set; } = true;

		public bool AnyDetected { get => this.GetInstallationDirectories().FirstOrDefault() != null; } // FIXME




		public InstallationDirectoryManager() : base() { }




		protected InstallationDirectory GetInstance(InstallationDirectory.DirectoryType type, string path)
			=> (this.GetCachedInstance(path) ?? this.SetCachedInstance(path, new InstallationDirectory(type, path)));




		public IEnumerable<InstallationDirectory> GetInstallationDirectoriesFromRegistry() {
			string path;
			InstallationDirectory.DirectoryType type;

			using (RegistryKey k_standalone = Registry.CurrentUser.OpenSubKey(@"Software\Eagle Dynamics")) {
				if (k_standalone != null) {
					foreach (string k in k_standalone.GetSubKeyNames().Where(k => k.StartsWith("DCS World"))) {
						if (k.Contains("Server")) {
							// not supporting server instances for now
							continue;
						}

						using (RegistryKey k_install = k_standalone.OpenSubKey(k)) {
							if (k_install == null) {
								continue;
							}

							path = Normalize.FilesystemPath((string)k_install.GetValue("Path"));
							type = VerifyInstallation(path);
							if (type != InstallationDirectory.DirectoryType.Unknown) {
								yield return this.GetInstance(type, path);
							}
						}
					}
				}
			}

			using (RegistryKey k_steam = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 223750")) {
				if (k_steam != null) {
					path = Normalize.FilesystemPath((string)k_steam.GetValue("InstallLocation"));
					type = VerifyInstallation(path);
					if (type != InstallationDirectory.DirectoryType.Unknown) {
						yield return this.GetInstance(type, path);
					}
				}
			}
		}




		public IEnumerable<InstallationDirectory> GetInstallationDirectories() {
			if (this.UseRegistry) {
				foreach (InstallationDirectory directory in this.GetInstallationDirectoriesFromRegistry()) {
					yield return directory;
				}
			}
		}




		public InstallationDirectory GetPrimaryInstallationDirectory() {
			// TODO
			return this.GetInstallationDirectories().First();
		}




		#region Static

		private static readonly string RetailChannelFile = "Config/retail.cfg";

		private static readonly Dictionary<string, InstallationDirectory.DirectoryType> RetailChannels = new Dictionary<string, InstallationDirectory.DirectoryType>(StringComparer.OrdinalIgnoreCase) {
			{ "ED", InstallationDirectory.DirectoryType.Standalone },
			{ "STEAM", InstallationDirectory.DirectoryType.Steam }
		};

		private static readonly string[] VerifyFilePaths = new string[] {
			RetailChannelFile,

			"dcs_manifest.bin",
			"bin/DCS.exe",
			"MissionEditor/MissionEditor.lua"
		};

		public static InstallationDirectory.DirectoryType VerifyInstallation(string path) {
			foreach (string file in VerifyFilePaths) {
				if (!File.Exists($"{path}/{file}")) {
					return InstallationDirectory.DirectoryType.Unknown;
				}
			}

			using (FileStream stream = File.OpenRead($"{path}/{RetailChannelFile}")) {
				using (StreamReader reader = new StreamReader(stream)) {
					if (RetailChannels.TryGetValue(reader.ReadLine()?.Trim(), out InstallationDirectory.DirectoryType type)) {
						return type;
					}
				}
			}

			return InstallationDirectory.DirectoryType.Unknown;
		}

		#endregion

	}

}
