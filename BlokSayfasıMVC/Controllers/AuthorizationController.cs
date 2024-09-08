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
    public class AuthorizationController : Controller
    {
        AdminManager adminmanager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var adminvalues = adminmanager.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {

            List<SelectListItem> roleList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "A", Value = "A" },
                    new SelectListItem { Text = "B", Value = "B" },
                    new SelectListItem { Text = "C", Value = "C" }
                };

            ViewBag.RoleList = roleList;
            return View();
        }


        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adminmanager.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> roleList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "A", Value = "A" },
                    new SelectListItem { Text = "B", Value = "B" },
                    new SelectListItem { Text = "C", Value = "C" }
                };

            ViewBag.RoleList = roleList;

            var adminvalue = adminmanager.GetByID(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adminmanager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}