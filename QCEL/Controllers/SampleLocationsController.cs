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

		// GET: SampleLocations/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: SampleLocations/EnvironmentalLabel
		public ActionResult Create()
		{
			return View();
		}


		// GET: SampleLocations/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}


		// GET: SampleLocations/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

	}
}