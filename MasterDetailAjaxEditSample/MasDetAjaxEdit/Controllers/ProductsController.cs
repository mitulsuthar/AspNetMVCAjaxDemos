using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasDetAjaxEdit.Models;
using System.Data.Entity;
using System.Data;
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
        [HttpPost]
        public PartialViewResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var editedProduct = db.Products.Find(product.ProductID);
                    editedProduct.Color = product.Color;
                    db.Entry(editedProduct).State = EntityState.Modified;
                    db.SaveChanges();
                    return PartialView("_EditParital",editedProduct);
                }
            }
            catch (DataException dex )
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            var oldProduct = db.Products.Find(product.ProductID);
            return PartialView("_EditPartial", oldProduct);
        }

    }
}