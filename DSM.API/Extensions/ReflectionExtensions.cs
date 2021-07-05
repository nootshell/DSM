using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;




namespace DSM.API.Extensions {

	public static class ReflectionExtensions {

		public static TAttribute GetAttribute<TAttribute>(this Type type, bool inherit) where TAttribute : Attribute
			=> (TAttribute)Attribute.GetCustomAttribute(type, typeof(TAttribute), inherit);

		public static TAttribute GetAttribute<TAttribute>(this Type type) where TAttribute : Attribute
			=> GetAttribute<TAttribute>(type, false);

	}

}
