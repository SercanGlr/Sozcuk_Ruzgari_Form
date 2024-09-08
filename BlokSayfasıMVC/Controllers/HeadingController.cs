using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlokSayfasıMVC.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());                                 //Bir parametre verme sebebimiz Manager kısmındaki constructor metodun bir parametre almak istemesidir.
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()                                //Dropdown kullanarak kategori vb. nin id yazmak yerine liste şeklinde geldi.
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,                             //display member = alınan değerin adı.
                                                      Value = x.CategoryID.ToString()                    //value member = alınan değerin id'si    
                                                  }
                                                 ).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }
                                                ).ToList();

            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());           //Tarihin anlık tarih olarak alınmasını sağladık.
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,                         
                                                      Value = x.CategoryID.ToString()                    
                                                  }
                                     ).ToList();
            ViewBag.vlc = valuecategory;

            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }

        public ActionResult HeadingReport()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
    }
}