using System.Web;
using System.Web.Mvc;

namespace QCEL
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			//Add global filter to make sure they are logged in to access the application
			filters.Add(new AuthorizeAttribute());

			filters.Add(new HandleErrorAttribute());
		}
	}
}
