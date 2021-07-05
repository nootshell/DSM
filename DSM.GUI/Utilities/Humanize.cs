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

	}

}
