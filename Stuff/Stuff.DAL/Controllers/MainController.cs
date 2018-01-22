using Stuff.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stuff.DAL.Controllers
{
    public class MainController : Controller
    {
        EmployeeRepository repoEmpl = new EmployeeRepository();
        CompanyRepository repoComp = new CompanyRepository();
        // GET: Main
        public ActionResult Index()
        {

            ViewBag.ReadComp = repoComp.Read();
            ViewBag.ReadEmpl = repoEmpl.Read();
            return View();
        }
    }
}