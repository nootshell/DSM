using System;




namespace DSM.GUI.Utilities {

	public static class Humanize {

		public static string Datetime(DateTime? datetime) {
			if (datetime == null) {
				return "present";
			}

			DateTime dt = (DateTime)datetime;
			return $"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2}";
		}




		public const ulong KiB = 1024;
		public const ulong MiB = (KiB * KiB);
		public const ulong GiB = (MiB * KiB);
		public const ulong TiB = (GiB * KiB);
		public const ulong PiB = (TiB * KiB);

		internal static string FileSize(ulong size, ulong si, string sis, string fmt = "F2") {
			return $"{((double)size / (double)si).ToString(fmt)} {sis}";
		}

		public static string FileSizeB(ulong size) => FileSize(size, 1, "B", "F0");
		public static string FileSizeKiB(ulong size) => FileSize(size, KiB, nameof(KiB));
		public static string FileSizeMiB(ulong size) => FileSize(size, MiB, nameof(MiB));
		public static string FileSizeGiB(ulong size) => FileSize(size, GiB, nameof(GiB));
		public static string FileSizeTiB(ulong size) => FileSize(size, TiB, nameof(TiB));
		public static string FileSizePiB(ulong size) => FileSize(size, PiB, nameof(PiB));

		public static string FileSize(ulong size) {
			if (size < KiB) {
				return FileSizeB(size);
			} else if (size < MiB) {
				return FileSizeKiB(size);
			} else if (size < GiB) {
				return FileSizeMiB(size);
			} else if (size < TiB) {
				return FileSizeGiB(size);
			} else if (size < PiB) {
				return FileSizeTiB(size);
			} else {
				return FileSizePiB(size);
			}
		}

	}

}
