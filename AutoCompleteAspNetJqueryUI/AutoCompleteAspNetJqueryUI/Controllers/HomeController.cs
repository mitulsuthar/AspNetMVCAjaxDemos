using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoCompleteAspNetJqueryUI.Models;
namespace AutoCompleteAspNetJqueryUI.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorks2012Entities db = new AdventureWorks2012Entities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Find(string prefixText)
        {
            var suggestedUsers = from x in db.People
                                 where x.LastName.StartsWith(prefixText)
                                 select new { id = x.BusinessEntityID, 
                                     value = x.LastName + ", " + x.FirstName, 
                                     firstname = x.FirstName, 
                                     lastname = x.LastName };
            var result = Json(suggestedUsers.Take(5).ToList());
            return result;
        }
        public ActionResult Details(int id = 0)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
    }
}
