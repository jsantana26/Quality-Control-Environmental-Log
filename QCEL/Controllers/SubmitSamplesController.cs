﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QCEL.Excel;
using QCEL.Models;
using QCEL.ViewModels;

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
			var viewModel = new SubmitSampleViewModel
			{
				Samples = _context.EnvironmentalSamples.Where(c => c.Submitted == false).ToList(),
				SelectedSamples = new List<EnvironmentalSample>()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Submit(FormCollection collection)
		{
			//Form collection returns Id's in a comma separated string ex: "1,2,3,4"
			var collectionIdString = collection["SelectedSamples"];

			if (collectionIdString == null)
				return RedirectToAction("Index");

			//Convert the string of comma separated values to a list on ints
			var idList = collectionIdString.Split(',').Select(int.Parse).ToList();

			//Create new list that will hold the selected samples
			var SelectedSamples = new List<EnvironmentalSample>();

			//Add each sample based on the id
			foreach (var id in idList)
			{
				SelectedSamples.Add(_context.EnvironmentalSamples.SingleOrDefault(c => c.Id == id));
			}

			return View(SelectedSamples);
		}


		public ActionResult Print(string samples)
		{
			List<EnvironmentalSample> samplesToPrint = System.Web.Helpers.Json.Decode<List<EnvironmentalSample>>(samples);

			CreateSheet.SarfForm(samplesToPrint);

			foreach (var sample in samplesToPrint)
			{
				var sampleInDb = _context.EnvironmentalSamples.SingleOrDefault(c => c.Id == sample.Id);
				sampleInDb.Submitted = true;
				_context.SaveChanges();
			}

			return RedirectToAction("Index");
		}
	}
}