using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinnesLayer.ValidationRules;

namespace MVC_ProjeKamp.Controllers
{
    public class UserWriterController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        Context c = new Context();
      


        [HttpGet]
        public ActionResult WriterProfile(int id=0) //başta 0 demek(boş dönmesin diye)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writervalue = wm.GetByID(id);
            return View(writervalue);

        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer) //başta 0 demek(boş dönmesin diye)
        {
            ValidationResult results = writerValidator.Validate(writer); //writervalidator sınıfında olan değerlere göre writer nesnesini validate(kontrol) et.
            if (results.IsValid)
            {
                wm.WriterUpdateBL(writer);
                return RedirectToAction("WriterProfile");
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

        public ActionResult MyHeading(string p)
        {   
            p = (string)Session["WriterMail"];
            var writeridvalue = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var headingvalues = hm.GetHeadingListByIDBL(writeridvalue);
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valuecategory = (from x in cm.GetCategoryListBL()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridvalue = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            heading.WriterID = writeridvalue;
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAddBL(heading);
            return RedirectToAction("MyHeading");
  
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {

            //KATEGORİLER DROPDOWNA TAŞIMA
            List<SelectListItem> valuecategory = (from x in cm.GetCategoryListBL()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();


            ViewBag.vlc = valuecategory;
            var headingvalue = hm.GetByIDBL(id);
            return View("UpdateHeading", headingvalue);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetByIDBL(id);
            hm.HeadingDelete(headingvalues);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeadings(int p=1)
        {
            var headings = hm.GetHeadingList().ToPagedList(p,4);
            return View(headings);
        }

    }
}