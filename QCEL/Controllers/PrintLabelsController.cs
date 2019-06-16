using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using QCEL.Excel;
using QCEL.Models;

namespace QCEL.Controllers
{
    public class PrintLabelsController : Controller
    {
	    private ApplicationDbContext _context;

		public PrintLabelsController()
		{
			_context = new ApplicationDbContext();
		}

        // GET: PrintLabels
        public ActionResult Index()
        {
			var userId = User.Identity.GetUserId();
			var currentUser = _context.Users.FirstOrDefault(x => x.Id == userId);
			var userInitials = currentUser.FirstName[0].ToString() + currentUser.LastName[0].ToString();

			//Get samples from db that match the user's initials
			var samples = _context.EnvironmentalSamples.Where(c => c.Initials == userInitials).Where(c => c.LabelPrinted == false).ToList();

			return View(samples);
        }

        public ActionResult ConfirmSelection(FormCollection collection)
        {
	        //Form collection returns Id's in a comma separated string ex: "1,2,3,4"
	        var collectionIdString = collection["SelectedSamples"];

	        if (collectionIdString == null)
		        RedirectToAction("Index");

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
	        List<EnvironmentalSample> samplesToPrint =
		        System.Web.Helpers.Json.Decode<List<EnvironmentalSample>>(samples);

	        CreateSheet.EnvironmentalLabel(samplesToPrint);

	        return RedirectToAction("Index");
        }
	}
}