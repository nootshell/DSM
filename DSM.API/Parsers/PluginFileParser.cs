using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Relua;
using Relua.AST;

using DSM.API.Modules;
using DSM.API.Utilities;

namespace DSM.API.Parsers {

	internal class PluginFileParser {

		private static readonly string[] IconPaths = new string[] {
			"Theme/icon.png",
			"Skins/icon.png",
			"Skins/1/icon.png",
		};

		protected Block Root { get; private set; }

		public string Path { get; private set; }




		protected PluginFileParser() : base() { }

		public PluginFileParser(string path) : this() {
			string path_fs = Normalize.FilesystemPath(path);
			using (FileStream stream = File.OpenRead(path_fs)) {
				using (StreamReader reader = new StreamReader(stream)) {
					this.Path = path_fs;
					this.Root = (new Parser(reader)).Read();
				}
			}
		}




		protected virtual IExpression FindVariableValue(string name, Func<IExpression, bool> check, IStatement origin) {
			Variable var;
			Assignment ass;
			IExpression expr;
			foreach (IStatement statement in this.Root.Statements) {
				if (statement == origin) {
					return null;
				}

				// TODO: this is a flat scan, maybe implement a hierarchical scan later?
				if ((ass = (statement as Assignment)) == null) {
					continue;
				}

				foreach (Variable target in ass.Targets) {
					if (target.Name != name) {
						continue;
					}

					foreach (IExpression value in ass.Values) {
						if ((var = (value as Variable)) == null) {
							if (check != null && !check(value)) {
								continue;
							}

							return value;
						}

						expr = this.FindVariableValue(var.Name, check, statement);
						if (expr != null) {
							return expr;
						}
					}
				}
			}

			return null;
		}


		protected virtual TExpression FindVariableValue<TExpression>(string name, Func<TExpression, bool> check, IStatement origin) where TExpression : class, IExpression {
			IExpression expr = this.FindVariableValue(
				name,
				(x) => (x is TExpression),
				origin
			);

			TExpression texpr = (expr as TExpression);
			if (check != null && !check(texpr)) {
				return null;
			}

			return texpr;
		}




		protected virtual string GetExpressionStringValue(IExpression expression) {
			if (expression is StringLiteral literal) {
				return literal.Value;
			} else if (expression is FunctionCall functionCall) {
				if (functionCall.Function is Variable function && function.Name != "_") {
					return null;
				}

				if (functionCall.Arguments?.Count < 1) {
					return null;
				}

				return this.GetExpressionStringValue(functionCall.Arguments[0]);
			}

			return null;
		}




		protected virtual void ParsePluginDeclaration<TModule>(TModule module, FunctionCall function, IStatement origin) where TModule : Module {
			if (function.Arguments.Count < 1) {
				throw new InvalidCastException();
			}

			IExpression arg1 = function.Arguments[1];

			TableConstructor ctor = null;
			if (arg1 is Variable var) {
				ctor = this.FindVariableValue<TableConstructor>(var.Name, null, origin);
			} else if (arg1 is TableConstructor tctor) {
				ctor = tctor;
			}

			if (ctor == null) {
				throw new InvalidOperationException();
			}

			foreach (TableConstructor.Entry entry in ctor.Entries) {
				string key = this.GetExpressionStringValue(entry.Key);

				if (entry.Value is BoolLiteral boolLiteral) {
					bool value = boolLiteral.Value;

					switch (key) {
						// utterly useless afaik, every module that gets through here is by definition installed. however, keeping this here as an example.
						case "installed":
							module.Installed = value;
							break;

						default: break;
					}
				} else {
					string value = this.GetExpressionStringValue(entry.Value);

					if (value != null) {
						switch (key) {
							case "localizedName":
							case "displayName":
								module.Name = value;
								break;

							case "shortName":
								module.ShortName = value;
								break;

							case "info":
								module.Info = value;
								break;

							case "update_id":
								module.UpdateSlug = value;
								break;

							case "state":
								module.Installed = (value == "installed");
								break;

							case "version":
								module.Version = value;
								break;

							case "developerName":
								module.Developer = value;
								break;

							default: break;
						}
					}
				}
			}
		}




		protected virtual void ParseFlyable<TModule>(TModule module, FunctionCall function, IStatement origin) where TModule : Module {
			if (function.Arguments.Count < 1) {
				throw new InvalidCastException();
			}

			IExpression arg0 = function.Arguments[0];
			string value = this.GetExpressionStringValue(arg0);
			if (value != null) {
				module.AddFilesystemSlug(value);
			}
		}




		public TModule Parse<TModule>() where TModule : Module, new() {
			string path_pr = Normalize.ProcessableFilesystemPath(this.Path);

			TModule module = new TModule {
				PluginFile = this.Path,
				InstallPath = Normalize.FilesystemPath(path_pr.Substring(0, path_pr.LastIndexOf("/")))
			};

			foreach (string icon in IconPaths) {
				if (File.Exists(Normalize.FilesystemPath($"{module.InstallPath}/{icon}"))) {
					module.IconPathRelative = icon;
					break;
				}
			}

			foreach (IStatement statement in this.Root.Statements) {
				if (statement is FunctionCall functionCall) {
					Variable fn = (Variable)functionCall.Function;

					switch (fn.Name) {
						case "declare_plugin":
							this.ParsePluginDeclaration(module, functionCall, statement);
							break;

						case "make_flyable":
							this.ParseFlyable(module, functionCall, statement);
							break;
					}
				}
			}

			string fsslug = path_pr.Substring(0, path_pr.LastIndexOf("/"));
			fsslug = fsslug.Substring(fsslug.LastIndexOf("/") + 1);
			module.InstallPathSlug = fsslug;
			module.AddFilesystemSlugIfNone(fsslug);

			module.Finalize();
			return module;
		}

	}

}
