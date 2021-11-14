using System;

namespace DSM.API.Analyzers.Primitives {

	public class Range<T> where T : IComparable {

		public T Start { get; set; }
		public T End { get; set; }
		public object Tag { get; set; }




		public Range(T start, T end) : base() {
			this.Start = start;
			this.End = end;
		}

	}

}
