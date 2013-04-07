using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetDemo4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        /// <summary>
        /// Public method that returns a PartialView
        /// </summary>
        /// <returns></returns>
        //public PartialViewResult GetSandwiches(string dishName, string ingredients)
        //{
        //    //Store some data into ViewBag using a variable called Tiffin.
        //    //Tiffin has a string value of Veggie Sandwiches.
        //    ViewBag.Tiffin = dishName + " with " + ingredients ;

        //    //Name of our PartialView is Restaurant
        //    return PartialView("_Restaurant");
        //}
                
        public async Task<PartialViewResult> GetSandwiches(string dishName, string ingredients)
        {   
            ViewBag.Tiffin = await GetDishAsync(dishName, ingredients);
            return PartialView("_Restaurant");
        }
        public async Task<string> GetDishAsync(string _dishName, string _ingredients)
        {
            await Task.Delay(2000); //Wait for 2 seconds. 
            return "Your order " + _dishName + " with " + _ingredients + " was completed at " + DateTime.Now.ToString();
        }
    }
}
