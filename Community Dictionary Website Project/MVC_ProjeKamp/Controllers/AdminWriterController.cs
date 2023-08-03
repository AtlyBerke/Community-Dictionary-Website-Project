using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    public class AdminWriterController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        public ActionResult Index()
        {
            //LIST
            var writervalues = wm.GetListBL();
            return View(writervalues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
          


            ValidationResult results = writerValidator.Validate(writer); //writervalidator sınıfında olan değerlere göre writer nesnesini validate(kontrol) et.
            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    writer.WriterImage = "/Image/" + dosyaadi + uzanti;

                }
                wm.WriterAddBL(writer);
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

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writervalues = wm.GetByID(id);
            return View("UpdateWriter", writervalues);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer); //writervalidator sınıfında olan değerlere göre writer nesnesini validate(kontrol) et.
            if (results.IsValid)
            {
                wm.WriterUpdateBL(writer);
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
    }
}