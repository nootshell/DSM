using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using DSM.API.Utilities;

namespace DSM.API.Plugins.Base {

	public abstract class PluginPathInfo : IDisposable {

		public string Path { get; set; }
		public PluginPathType Type { get; set; }

		protected IDisposable Disposable { get; set; }

		public string Slug { get => SlugHelper.GetSlug(this.Path); }




		protected PluginPathInfo() : base() { }

		public PluginPathInfo(string path, PluginPathType type) : this() {
			this.Path = Normalize.FilesystemPath(path);
			this.Type = ResolvePathType(path, type);
		}

		public static PluginPathType ResolvePathType(string path, PluginPathType hint) {
			switch (hint) {
				case PluginPathType.Directory:
				case PluginPathType.ZipArchive:
					return hint;

				default:
					break;
			}

			if (File.Exists(path)) {
				if (path.EndsWith(".zip")) {
					return PluginPathType.ZipArchive;
				}
			} else if (Directory.Exists(path)) {
				return PluginPathType.Directory;
			}

			return PluginPathType.Unknown;
		}




		public bool Exists() {
			switch (this.Type) {
				case PluginPathType.Directory:
					return Directory.Exists(this.Path);

				case PluginPathType.ZipArchive:
					return File.Exists(this.Path);

				default:
					return false;
			}
		}


		protected virtual void Verify() {
			switch (this.Type) {
				case PluginPathType.Directory:
				case PluginPathType.ZipArchive:
					return;

				case PluginPathType.Auto:
				case PluginPathType.Unknown:
					throw new InvalidOperationException("The location has an unresolved or unknown type.");

				default:
					throw new InvalidOperationException("Unsupported location type.");
			}
		}




		protected virtual ZipArchive OpenZipArchive() {
			if (this.Type != PluginPathType.ZipArchive) {
				throw new InvalidOperationException("This instance has an invalid type.");
			}

			if (this.Disposable is ZipArchive archive) {
				return archive;
			} else if (this.Disposable != null) {
				throw new InvalidOperationException("This instance already has a disposable set.");
			}

			return (ZipArchive)(this.Disposable = ZipFile.Open(this.Path, ZipArchiveMode.Read));
		}

		// TODO: support non-root entry files (for future repacking feature)
		protected virtual Stream OpenZipArchiveEntry(string entryname) {
			ZipArchive archive = this.OpenZipArchive();
			ZipArchiveEntry entry = archive.GetEntry(entryname);
			return entry.Open();
		}




		public virtual Stream GetFileStream(string relpath) {
			this.Verify();

			switch (this.Type) {
				case PluginPathType.Directory:
					return File.OpenRead(Normalize.FilesystemPath($"{this.Path}/{relpath}"));

				case PluginPathType.ZipArchive:
					return this.OpenZipArchiveEntry(relpath);

				default:
					throw new InvalidOperationException("Should not be getting here.");
			}
		}




		#region IDisposable
		private bool __disposed = false;

		protected virtual void Dispose(bool disposing) {
			if (!this.__disposed) {
				if (disposing) {
					this.Disposable?.Dispose();
				}

				this.__disposed = true;
			}
		}

		public void Dispose() {
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

	}

}