using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QCEL.Models;

namespace QCEL.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationDbContext _context;

		public HomeController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			var todaysSamples = _context.EnvironmentalSamples.Count(c => c.CollectionDate == DateTime.Today);
			var pendingSamples = _context.EnvironmentalSamples.Count(c => c.Submitted == false);

			ViewBag.TodaysSamples = todaysSamples;
			ViewBag.PendingSamples = pendingSamples;

			if(User.IsInRole(RoleName.CanManageAccounts) || User.IsInRole(RoleName.CanManageSampleLocations))
				return View("AdminIndex");

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}