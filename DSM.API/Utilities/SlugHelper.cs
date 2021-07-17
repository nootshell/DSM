using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DSM.API.Utilities {

	public static class SlugHelper {

		public static string GetSlug(string path) {
			string path_pr = Normalize.ProcessableFilesystemPath(path);

			int idx = path_pr.LastIndexOf("/");
			if (idx < 0) {
				// TODO
				throw new InvalidOperationException();
			}

			return path_pr.Substring(idx + 1);
		}

	}

}
