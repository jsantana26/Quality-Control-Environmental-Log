using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using AutoMapper;
using QCEL.Dtos;
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

		public ActionResult Edit(int id)
		{
			var sample = _context.SampleLocations.SingleOrDefault(c => c.Id == id);

			if (sample == null)
				return HttpNotFound();

			return View(sample);
		}

		public ActionResult Save(SampleLocationDto sampleLocationDto)
		{
			if (!ModelState.IsValid)
				return HttpNotFound();

			var sampleLocationInDb = _context.SampleLocations.SingleOrDefault(c => c.Id == sampleLocationDto.Id);

			if (sampleLocationInDb == null)
				return HttpNotFound();

			Mapper.Map(sampleLocationDto, sampleLocationInDb);

			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}