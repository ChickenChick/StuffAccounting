using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.DAL.Models;
using Stuff.DAL.Repositories;

namespace Stuff.DAL.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(Company company)
        {
            using (CompanyRepository repo = new CompanyRepository())
            {
                repo.Update(company);
                return RedirectToAction("Read");
            }
        }

        public ActionResult Read()
        {
            using (CompanyRepository repo = new CompanyRepository())
            {
                return View(repo.Read());
            }
        }
    }
}