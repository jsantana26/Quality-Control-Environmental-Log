using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
			var userId = User.Identity.GetUserId();
			var currentUser = _context.Users.FirstOrDefault(x => x.Id == userId);
			var userInitials = currentUser.FirstName[0].ToString() + currentUser.LastName[0].ToString();

			var todaysSamples = _context.EnvironmentalSamples.Count(c => c.CollectionDate == DateTime.Today);
			var pendingSamples = _context.EnvironmentalSamples.Count(c => c.Submitted == false);
			var labelsReady = _context.EnvironmentalSamples
				.Where(c => c.LabelPrinted == false)
				.Count(c => c.Initials == userInitials);

			ViewBag.TodaysSamples = todaysSamples;
			ViewBag.PendingSamples = pendingSamples;
			ViewBag.LabelsReady = labelsReady;

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