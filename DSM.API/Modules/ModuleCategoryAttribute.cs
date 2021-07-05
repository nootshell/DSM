using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DSM.API.Modules {

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class ModuleCategoryAttribute : Attribute {

		public string Category { get; protected set; }




		public ModuleCategoryAttribute(string category) : base() {
			this.Category = category;
		}

	}

}
