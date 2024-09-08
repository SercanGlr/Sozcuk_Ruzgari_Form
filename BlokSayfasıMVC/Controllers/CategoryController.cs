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
//Sadece kategori kısmına ait işlemler burada tutulur.
namespace BlokSayfasıMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()  //Bu sayfa için bir view açtıktan sonra view>category adında bir klasör oluşur ve onun altında index sayfası görüntülenebilir.
        {
            return View();
        }
       
        public ActionResult CategoryList()            //Kategoriyi listeleme için kullanılır
        {
                var categoryvalues = cm.GetList();       //Business layer'a gittik o bizi Dal'a generic repositoriye gönderdi ordan da Listelemeyi aldık
                return View(categoryvalues);            //categoryvalues değerini(kısaca kategori listesi) sayfaya gönderdik.
        }

        [HttpPost]                                      //Bir eylem olduğunda HttpPost kullanılır.
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("CategoryList");
            }

            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

            return RedirectToAction("CategoryList");     //ekleme işlemini gerçekleştirdikten sonra listelemeyi yaptığımız kısma geri döndürdük.
        }
        
        [HttpGet]                                       //Bir eylem yoksa HttpGet kullanılır.
        public ActionResult AddCategory()               
        {
            return View();
        }
    }

} 