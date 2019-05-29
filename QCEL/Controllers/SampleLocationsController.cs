using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QCEL.Models;
using QCEL.ViewModels;

namespace QCEL.Controllers
{
	public class SampleLocationsController : Controller
	{
		// GET: SampleLocations
		public ActionResult Index()
		{
			var sampleLocations = new List<SampleLocation>()
			{
				new SampleLocation(){
					Id = 1,
					SampleNumber = "BL1",
					Location = "BL1 Wash area drain",
					MicroTest = "Listeria SP",
					ProductCode = "Sponge",
					RequestType = "Environmental",
					Type = "Sponge Sample/1",
					Zone = "3"
				},
				new SampleLocation(){
					Id = 2,
					SampleNumber = "BL2",
					Location = "BL1 Blender Floor",
					MicroTest = "Listeria SP",
					ProductCode = "Sponge",
					RequestType = "Environmental",
					Type = "Sponge Sample/1",
					Zone = "3"
				}
			};

			var viewModel = new SampleLocationsViewModel
			{
				SampleLocations = sampleLocations
			};

			return View(viewModel);
		}

		// GET: SampleLocations/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: SampleLocations/Create
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
