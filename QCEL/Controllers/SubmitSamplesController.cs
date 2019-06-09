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
	        var environmentalSample = _context.EnvironmentalSamples.Where(c => c.PendingSubmission).ToList();
            return View(environmentalSample);
        }
    }
}