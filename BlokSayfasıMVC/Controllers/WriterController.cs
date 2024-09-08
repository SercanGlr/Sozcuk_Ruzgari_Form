using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlokSayfasıMVC.Controllers
{
    public class WriterController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterValidator writerValidator = new WriterValidator();

        public ActionResult Index()
        {
            var writervalues = wm.GetList();
            return View(writervalues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult WriterUpdate(int id)
        {
            var writervalues = wm.GetByID(id);
            return View(writervalues);
        }

        [HttpPost]
        public ActionResult WriterUpdate(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult WriterHeadings()
        {
            return View();
        }
    }
}