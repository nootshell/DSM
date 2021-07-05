using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Relua;
using Relua.AST;

using DSM.API.Utilities;




namespace DSM.API.Modules {

	public abstract class Module {

		public string UpdateSlug { get; set; }
		public string FilesystemSlug { get; set; }

		public string ShortName { get; set; }
		public string Name { get; set; }

		public string Developer { get; set; }
		public string Info { get; set; }
		public string Version { get; set; }

		public bool Installed { get; set; }
		public string PluginFile { get; set; }
		public string InstallPath { get; set; }
		public string IconPathRelative { get; set; }
		public string IconPathAbsolute => ((this.IconPathRelative != null) ? Normalize.FilesystemPath($"{this.InstallPath}/{this.IconPathRelative}") : null);




		public string GetShortName()
			=> this.ShortName ?? this.FilesystemSlug;

		public string GetName()
			=> this.Name ?? this.GetShortName();




		private static readonly string[] IconPaths = new string[] {
			"Theme/icon.png",
			"Skins/icon.png",
			"Skins/1/icon.png",
		};

		public static TModule FromPluginFile<TModule>(string path) where TModule : Module, new() {
			TModule module = null;

			string path_fs = Normalize.FilesystemPath(path);
			using (FileStream stream = File.OpenRead(path_fs)) {
				using (StreamReader reader = new StreamReader(stream)) {
					Parser parser = new Parser(reader);

					Block block = parser.Read();
					foreach (IStatement statement in block.Statements) {
						if (!(statement is FunctionCall)) {
							continue;
						}

						FunctionCall call = (FunctionCall)statement;
						Variable function = (Variable)call.Function;
						if (function.Name == "declare_plugin") {
							string path_pr = Normalize.ProcessableFilesystemPath(path);

							module = new TModule();
							module.PluginFile = path_fs;
							module.InstallPath = Normalize.FilesystemPath(path_pr.Substring(0, path_pr.LastIndexOf("/")));

							foreach (string icon in IconPaths) {
								if (File.Exists(Normalize.FilesystemPath($"{module.InstallPath}/{icon}"))) {
									module.IconPathRelative = icon;
									break;
								}
							}


							//! oh my god, FIXME!
							string fsslug = path_pr.Substring(0, path_pr.LastIndexOf("/"));
							fsslug = fsslug.Substring(fsslug.LastIndexOf("/") + 1);
							module.FilesystemSlug = fsslug;

							TableConstructor table = null;
							if (call.Arguments[1] is Variable table_var) {
								foreach (IStatement backtrack in block.Statements) {
									if (backtrack == statement) {
										// boo!
										break;
									}

									if (backtrack is Assignment ass) {
										foreach (Variable var in ass.Targets) {
											if (var.Name != table_var.Name) {
												continue;
											}

											foreach (IExpression expr in ass.Values) {
												if (!(expr is TableConstructor)) {
													continue;
												}

												table = (TableConstructor)expr;
												break;
											}

											break;
										}
									}
								}
							} else if (call.Arguments[1] is TableConstructor t_ctor) {
								table = t_ctor;
							}

							if (table == null) {
								// could not find appropriate plugin table
								throw new InvalidOperationException("File did not contain a proper declare_plugin.");
							}

							foreach (TableConstructor.Entry entry in table.Entries) {
								if (!(entry.Key is StringLiteral)) {
									continue;
								}

								IExpression value_expr;
								if (entry.Value is FunctionCall entry_call) {
									if (entry_call.Function is Variable entry_function && entry_function.Name != "_") {
										continue;
									}

									if (!(entry_call.Arguments[0] is StringLiteral)) {
										continue;
									}

									value_expr = (StringLiteral)entry_call.Arguments[0];
								} else {
									value_expr = entry.Value;
								}

								string key = ((StringLiteral)entry.Key).Value;

								if (value_expr is StringLiteral string_literal) {
									string value = string_literal.Value;

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
									}
								} else if (value_expr is BoolLiteral bool_literal) {
									bool value = bool_literal.Value;

									switch (key) {
										case "installed":
											module.Installed = value;
											break;
									}
								}
							}
						}
					}
				}
			}

			return module;
		}




		public override string ToString() {
			return $"{this.GetType().Name} ({this.Name})";
		}

	}

}
