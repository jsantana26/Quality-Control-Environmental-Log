using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QCEL.Models;

namespace QCEL.Controllers
{
	public class SubmitSamplesController : Controller
	{
		private ApplicationDbContext _context;

		public SubmitSamplesController()
		{
			_context = new ApplicationDbContext();
		}

		// GET: SubmitSamples
		public ActionResult Index()
		{
			var environmentalSample = _context.EnvironmentalSamples.Where(c => c.Submitted == false).ToList();
			return View(environmentalSample);
		}

		public ActionResult Submit(List<EnvironmentalSample> samples)
		{
			var environmentalSample = _context.EnvironmentalSamples.Where(c => c.Submitted == false).ToList();
			if (samples == null)
				return View("Index", environmentalSample);

			foreach (var sample in samples)
			{
				if (sample.Submitted)
				{
					//TODO: Update the database to make sample submitted
				}
			}

			return View("Index", environmentalSample);
		}
	}
}