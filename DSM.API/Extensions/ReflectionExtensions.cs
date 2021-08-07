using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;




namespace DSM.API.Extensions {

	public static class ReflectionExtensions {

		public static TAttribute GetAttribute<TAttribute>(this MemberInfo type, bool inherit) where TAttribute : Attribute
			=> (TAttribute)Attribute.GetCustomAttribute(type, typeof(TAttribute), inherit);

		public static TAttribute GetAttribute<TAttribute>(this MemberInfo type) where TAttribute : Attribute
			=> GetAttribute<TAttribute>(type, false);




		public static string ToDescriptiveString<TEnum>(this TEnum value) where TEnum : Enum {
			string s_value = value.ToString();

			DescriptionAttribute attr;
			foreach (MemberInfo member in typeof(TEnum).GetMember(s_value)) {
				attr = member.GetAttribute<DescriptionAttribute>(false);
				if (attr != null) {
					return attr.Description;
				}
			}

			return s_value;
		}




		public static IEnumerable<Type> GetDerivativeTypes(this Type type, Assembly assembly = null) {
			if (assembly == null) {
				assembly = Assembly.GetAssembly(type);
			}

			foreach (Type t in assembly.GetTypes()) {
				if (!t.IsSubclassOf(type)) {
					continue;
				}

				yield return t;
			}
		}

	}

}
