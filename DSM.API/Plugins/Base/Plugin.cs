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
			get => (this.Target?.Exists() == true);
		}

		public SourceInfo Source { get; set; }
		public TargetInfo Target { get; set; }

		protected virtual string EntryFile { get; private set; }




		public string Path {
			get => this.GetPrimaryPathInfo().Path;
		}

		public string Slug {
			get => this.GetPrimaryPathInfo().Slug;
		}

		public ulong Size {
			get => this.GetPrimaryPathInfo().Size;
		}

		public PluginPathType Type {
			get => this.GetPrimaryPathInfo().Type;
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

		public Plugin(SourceInfo source, TargetInfo target) : this() {
			this.Source = source;
			this.Target = target;

			this.InitFromEntryFile();
		}

		public Plugin(string sourcePath, PluginPathType sourceType, string targetPath, PluginPathType targetType) : this() {
			if (sourcePath != null) {
				this.Source = new SourceInfo(sourcePath, sourceType);
			}

			if (targetPath != null) {
				this.Target = new TargetInfo(targetPath, targetType);
			}

			this.InitFromEntryFile();
		}

		public Plugin(string path, PluginPathType type, bool installed) : this()
			=> this.alt_ctor(path, type, installed);

		public Plugin(string path, bool installed) : this()
			=> this.alt_ctor(path, installed);




		internal void alt_ctor(string path, PluginPathType type, bool installed) {
			if (installed) {
				this.Target = new TargetInfo(path, type);
			} else {
				this.Source = new SourceInfo(path, type);
			}

			this.InitFromEntryFile();
		}

		internal void alt_ctor(string path, bool installed)
			=> this.alt_ctor(path, PluginPathType.Auto, installed);


		internal virtual void FinalizeInit() {
			// TODO: this.Source?.FinalizeInit(installIntended);
			// for now keep sources open, since those are most likely going to be installed and therefore reopened
			this.Target?.FinalizeInit();
		}




		public virtual PluginPathInfo GetPrimaryPathInfo()
			=> (this.Installed ? (PluginPathInfo)this.Target : (PluginPathInfo)this.Source);


		protected virtual Stream GetEntryFileStream()
			=> this.GetPrimaryPathInfo().GetFileStream(this.EntryFile);


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
					this.Source?.Dispose();
					this.Target?.Dispose();
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
