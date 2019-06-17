using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QCEL.Models;

namespace QCEL.Controllers
{
	public class SampleLocationsController : Controller
	{
		private ApplicationDbContext _context;

		public SampleLocationsController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: SampleLocations
		public ActionResult Index()
		{
			if (User.IsInRole(RoleName.CanManageSampleLocations))
				return View("List");

			return View("ReadOnlyList");
		}
	}
}