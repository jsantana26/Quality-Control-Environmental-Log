using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QCEL.Models;
using QCEL.ViewModels;

namespace QCEL.Controllers
{
    public class ArchiveController : Controller
    {
	    private ApplicationDbContext _context;

	    public ArchiveController()
	    {
		    _context = new ApplicationDbContext();
	    }
        // GET: Archive
        public ActionResult Index()
        {
	        var viewModel = new DateRangeViewModel
	        {
		        EnvironmentalSamples = _context.EnvironmentalSamples.ToList()
	        };
            return View(viewModel);
        }

        public ActionResult FilterDate(DateRangeViewModel viewModel)
        {
	        if (!ModelState.IsValid)
		        return RedirectToAction("Index");

	        if (viewModel.FromDate == null)
				viewModel.FromDate = DateTime.Today;

			if(viewModel.ToDate == null)
				viewModel.ToDate = DateTime.Today;

			viewModel.ToDate = new DateTime(viewModel.ToDate.Value.Year, viewModel.ToDate.Value.Month, DateTime.DaysInMonth(viewModel.ToDate.Value.Year, viewModel.ToDate.Value.Month));

	        viewModel.EnvironmentalSamples = _context.EnvironmentalSamples
		        .Where(c => c.CollectionDate >= viewModel.FromDate && c.CollectionDate <= viewModel.ToDate)
		        .ToList();

	        return View("Index", viewModel);
        }
    }
}