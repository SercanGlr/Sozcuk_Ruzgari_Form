using BlokSayfasıMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlokSayfasıMVC.Controllers
{
    public class ChartController : Controller
    {

        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass() { CategoryName = "Spor", CategoryCount = 8 });
            ct.Add(new CategoryClass() { CategoryName = "Tiyatro", CategoryCount = 4 });
            ct.Add(new CategoryClass() { CategoryName = "Teknoloji", CategoryCount = 1 });
            ct.Add(new CategoryClass() { CategoryName = "Meslekler", CategoryCount = 7 });

            return ct;
        }
    }
}