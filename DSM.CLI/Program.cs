using System;

using DSM.API;
using DSM.API.Installables.Modules;




namespace DSM.CLI {

	internal class Program {

		private static void Help(string[] args) {
			Console.WriteLine("Halp");
		}

		private static void Main(string[] args) {
			if (args.Length == 0 || args[0] == "help") {
				Help(args);
				return;
			}

			DSMContext context = new DSMContext();

			switch (args[0]) {
				case "module":
					if (args.Length < 2) {
						Help(args);
						return;
					}

					switch (args[1]) {
						case "list":
							foreach (Aircraft module in context.InstallationDirectory.Mods.GetModules<Aircraft>()) {
								Console.WriteLine(module);
							}
							foreach (Terrain module in context.InstallationDirectory.Mods.GetModules<Terrain>()) {
								Console.WriteLine(module);
							}
							break;

						case "info":


						default:
							Help(args);
							return;
					}
					break;

				default:
					Help(args);
					return;
			}

		}

	}

}
