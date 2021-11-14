using DSM.API.Analyzers.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.API.Extensions {

	public static class RangeExtensions {

		public static IEnumerable<Range<T>> Collapse<T>(this IEnumerable<Range<T>> ranges, IComparer<T> comparer = null) where T : IComparable {
			if (ranges == null || !ranges.Any()) {
				yield break;
			}

			if (comparer == null) {
				comparer = Comparer<T>.Default;
			}

			IOrderedEnumerable<Range<T>> ranges_ordered = ranges.OrderBy(x => x.Start);
			Range<T> range_first = ranges_ordered.First();

			T min = range_first.Start;
			T max = range_first.End;

			foreach (Range<T> range in ranges_ordered.Skip(1)) {
				if (comparer.Compare(range.End, max) > 0 && comparer.Compare(range.Start, max) > 0) {
					yield return new Range<T>(min, max) { Tag = range.Tag };
					min = range.Start;
				}
				max = ((comparer.Compare(max, range.End) > 0) ? max : range.End);
			}

			yield return new Range<T>(min, max) { Tag = range_first.Tag };
		}

	}

}
