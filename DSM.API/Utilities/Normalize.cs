using System.IO;




namespace DSM.API.Utilities {

	public static class Normalize {

		// TODO?: optimize for performance or leave it like this? not like we really need performance
		public static string ProcessableFilesystemPath(string path) {
			if (path == null) {
				return null;
			}

			path = path.Replace("\\", "/");
			while (path.Contains("//")) {
				path = path.Replace("//", "/");
			}

			return path;
		}

		// TODO?: optimize for performance or leave it like this? not like we really need performance
		public static string FilesystemPath(string path) {
			if (path == null) {
				return null;
			}

			return ProcessableFilesystemPath(path).Replace('/', Path.DirectorySeparatorChar);
		}

	}

}
