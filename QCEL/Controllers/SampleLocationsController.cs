using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
			return View();
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



/*
 * 
 * ,
                    {
                        data: "SampleNumber",
                        render: function(data, type, sampleNumber) {
                            return "<a href='/SampleLocations/edit/" +
                                sampleNumber.id +
                                "'>" +
                                sampleNumber.SampleLocation +
                                "</a>";
                        }
                    },
                    {
                        data: "Location"
                    },
                    {
                        data: "MicroTest"
                    },
                    {
                        data: "Type"
                    },
                    {
                        data: "ProductCode"
                    },
                    {
                        data: "Zone"
                    },
                    {
                        data: "RequestType"
                    },
                    {
                        data: "Id",
                        render: function(data) {
                            return "<button data-sampleLocation-id='" + data + " class='btn-link js-delete'>Delete</button>"
                        }
                    }
 * 
 */
