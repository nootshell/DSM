using DSM.API.Extensions;
using DSM.API.Utilities;
using Relua;
using Relua.AST;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DSM.API.Plugins.Base {

	public abstract class Plugin : IDisposable {


		public virtual bool Installed {
			get => (this.PathInfo?.Exists() == true);
		}

		public PluginPathInfo PathInfo { get; set; }
		public bool IsInstalled { get; set; }

		protected virtual string EntryFile { get; private set; }




		public string Path {
			get => this.PathInfo.Path;
		}

		public string PathSlug {
			get => this.PathInfo.PathSlug;
		}

		public ulong Size {
			get => this.PathInfo.Size;
		}

		public string Slug {
			get => this.PathInfo.Slug;
		}

		public PluginPathType Type {
			get => this.PathInfo.Type;
		}




		public static string GetEntryFile(Type type) {
			PluginEntryFileAttribute attr = type.GetAttribute<PluginEntryFileAttribute>(true);
			return attr?.EntryFile;
		}

		public static string GetEntryFile<T>() where T : Plugin
			=> GetEntryFile(typeof(T));




		protected Plugin() : base() {
			this.EntryFile = GetEntryFile(this.GetType());

			if (this.EntryFile == null) {
				throw new InvalidOperationException("Unable to find PluginEntryFileAttribute for this type.");
			}
		}

		public Plugin(string path, PluginPathType type, bool installed) : this()
			=> this.Init(path, type, installed);

		public Plugin(string path, bool installed) : this()
			=> this.Init(path, installed);




		internal void Init(string path, PluginPathType type, bool installed) {
			this.PathInfo = new PluginPathInfo(path, type);
			this.IsInstalled = installed;

			this.InitFromEntryFile();
		}

		internal void Init(string path, bool installed)
			=> this.Init(path, PluginPathType.Auto, installed);


		internal virtual void FinalizeInit() {
			// TODO: this.Source?.FinalizeInit(installIntended);
			// for now keep sources open, since those are most likely going to be installed and therefore reopened
			this.PathInfo?.FinalizeInit();
		}




		protected virtual Stream GetEntryFileStream()
			=> this.PathInfo.GetFileStream(this.EntryFile);


		protected abstract void InitFromEntryFileBlock(Block block);

		protected virtual void InitFromEntryFile() {
			using (Stream stream = this.GetEntryFileStream()) {
				using (StreamReader reader = new StreamReader(stream)) {
					this.InitFromEntryFileBlock((new Parser(reader)).Read());
				}
			}

			this.FinalizeInit();
		}




		#region IDisposable
		private bool __disposed = false;

		protected virtual void Dispose(bool disposing) {
			if (!this.__disposed) {
				if (disposing) {
					this.PathInfo?.Dispose();
				}

				this.__disposed = true;
			}
		}

		void IDisposable.Dispose() {
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

	}

}
