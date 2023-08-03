using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    public class AdminCategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        
 
        public ActionResult Index()
        {
            var categoryvalues = cm.GetCategoryListBL();
            return View(categoryvalues);
        }


        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c); //categoryvalidator sınıfında olan değerlere göre c nesnesini validate(kontrol) et.
            if (results.IsValid)
            {
                cm.CategoryAddBL(c);
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

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByIDBL(id);
            cm.CategoryDeleteBL(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryvalue = cm.GetByIDBL(id);
            return View("UpdateCategory", categoryvalue);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category c)
        {
            cm.CategoryUpdateBL(c);
            return RedirectToAction("Index");
        }
    }
}