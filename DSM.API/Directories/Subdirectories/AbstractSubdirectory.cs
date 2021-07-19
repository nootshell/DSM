using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.API.Directories.Subdirectories {

	public abstract class AbstractSubdirectory : AbstractDirectory {

		public AbstractDirectory ParentDirectory { get; protected set; }




		public AbstractSubdirectory(AbstractDirectory parentDirectory, string subdir) : base($"{parentDirectory.Path}/{subdir}") {
			this.ParentDirectory = parentDirectory;
		}

	}

}
