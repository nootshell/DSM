using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Relua;
using Relua.AST;

using DSM.API.Utilities;




namespace DSM.API.Modules {

	public abstract class Module {

		public string UpdateSlug { get; set; }
		public string[] FilesystemSlugs { get; set; }

		public string ShortName { get; set; }
		public string Name { get; set; }

		public string Developer { get; set; }
		public string Info { get; set; }
		public string Version { get; set; }

		public bool Installed { get; set; }

		public string PluginFile { get; set; }
		public string InstallPath { get; set; }
		public string InstallPathSlug { get; set; }

		public string IconPathRelative { get; set; }
		public string IconPathAbsolute => ((this.IconPathRelative != null) ? Normalize.FilesystemPath($"{this.InstallPath}/{this.IconPathRelative}") : null);




		public string PrettyFilesystemSlugs {
			get => string.Join(", ", this.FilesystemSlugs);
		}




		public string GetFirstFilesystemSlug() {
			if (this.FilesystemSlugs.Length < 1) {
				return null;
			}

			return this.FilesystemSlugs[0];
		}

		public string GetShortName()
			=> this.ShortName ?? this.GetFirstFilesystemSlug();

		public string GetName()
			=> this.Name ?? this.GetShortName();




		private IList<string> filesystemSlugs = new List<string>();

		internal void AddFilesystemSlug(string slug)
			=> this.filesystemSlugs.Add(slug);

		internal void AddFilesystemSlugIfNone(string slug) {
			if (this.filesystemSlugs.Count > 0) {
				return;
			}

			this.AddFilesystemSlug(slug);
		}




		internal void Finalize() {
			this.FilesystemSlugs = this.filesystemSlugs.ToArray();
		}




		public override string ToString() {
			return $"{this.GetType().Name} ({this.Name})";
		}

	}

}
