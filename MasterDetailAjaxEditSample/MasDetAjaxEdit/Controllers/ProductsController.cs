using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasDetAjaxEdit.Models;
namespace MasDetAjaxEdit.Controllers
{
    public class ProductsController : Controller
    {
        private AdventureWorks2012Entities db = new AdventureWorks2012Entities();
        [HttpGet]
        public ActionResult Edit()
        {
           var products = db.Products.ToList()
                              .Where(x => x.ListPrice > 0).Take(10);
           return View("Edit", products);
        }
        public PartialViewResult GetProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                return PartialView("_EditPartial", product);
            }
            return PartialView("Error");
        }
    }
}