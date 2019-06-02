using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QCEL.Models;

namespace QCEL.Controllers
{
	public class EmployeeController : Controller
	{
		private ApplicationDbContext _context;

		public EmployeeController()
		{
			_context = new ApplicationDbContext();
		}

		// GET: Employee
		public ActionResult Index()
		{
			if (User.IsInRole(RoleName.CanManageAccounts))
			{
				var employees = _context.Users.ToList();
				return View("List", employees);
			}

			return View("UnauthorizedView");
		}
	}
}