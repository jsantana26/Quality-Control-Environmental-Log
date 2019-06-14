using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using QCEL.Excel;
using QCEL.Models;
using QCEL.ViewModels;

namespace QCEL.Controllers
{
	public class EnvironmentalSamplesController : Controller
	{
		private ApplicationDbContext _context;

		public EnvironmentalSamplesController()
		{
			_context = new ApplicationDbContext();
		}

		// GET: Samples
		public ActionResult Index()
		{
			var environmentalSample = _context.EnvironmentalSamples.ToList();
			return View(environmentalSample);
		}

		public ActionResult New()
		{
			var sampleLocations = _context.SampleLocations.ToList();

			var viewModel = new NewEnvironmentalSampleViewModel
			{
				SampleLocations = sampleLocations
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(NewEnvironmentalSampleViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();
			var currentUser = _context.Users.FirstOrDefault(x => x.Id == userId);

			if (currentUser == null)
				return HttpNotFound();

			var sampleInfo = _context.SampleLocations.SingleOrDefault(c => c.Location == viewModel.EnvironmentalSample.Location);

			if (sampleInfo == null)
				return HttpNotFound();

			var newSample = new EnvironmentalSample
			{
				Location = viewModel.EnvironmentalSample.Location,
				CollectionDate = viewModel.EnvironmentalSample.CollectionDate,
				SampleNumber = sampleInfo.SampleNumber,
				MicroTest = sampleInfo.MicroTest,
				Zone = sampleInfo.Zone,
				ProductCode = sampleInfo.ProductCode,
				RequestType = sampleInfo.RequestType,
				Type = sampleInfo.Type,
				Initials = currentUser.FirstName[0].ToString() + currentUser.LastName[0].ToString(),
				Submitted = false
			};

			_context.EnvironmentalSamples.Add(newSample);
			_context.SaveChanges();

			GenerateLabel.EnvironmentalLabel(newSample);


			return RedirectToAction("Index", "EnvironmentalSamples");
		}

		
	}
}