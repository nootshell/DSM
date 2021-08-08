using System.Collections.Generic;




namespace DSM.API.Plugins.Modules {

	public interface ILiveryConfigurableModule {

		IEnumerable<Livery> GetLiveries(DSMContext context);

	}

}
