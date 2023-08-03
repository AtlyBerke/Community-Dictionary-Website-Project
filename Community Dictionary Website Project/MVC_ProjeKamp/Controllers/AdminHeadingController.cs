using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    public class AdminHeadingController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        
        // GET: AdminHeading
        public ActionResult Index(int p=1)
        {
            var headingvalues = hm.GetHeadingList().ToPagedList(p,4);
            return View(headingvalues);
        }
        
        public ActionResult HeadingReports()
        {
            var headingvalues = hm.GetHeadingList();
            return View(headingvalues);
        }

        public ActionResult HeadingsByCategory(int id)
        {
            var headingvalues = hm.GetHeadingListByCategory(id);
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            //KATEGORİLER DROPDOWNA TAŞIMA
            List<SelectListItem> valuecategory = (from x in cm.GetCategoryListBL()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;

            //YAZARLARI DROPDOWNA TAŞIMA
            List<SelectListItem> valuewriter = (from x in wm.GetListBL ()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName +" "+x.WriterSurname,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();

            ViewBag.vlw = valuewriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAddBL(heading);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetByIDBL(id);
            hm.HeadingDelete(headingvalues);
            return RedirectToAction("Index");
        }
    }
}