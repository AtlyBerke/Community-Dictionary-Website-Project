using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdmin_Dal());

        public ActionResult Index()
        {
            var adminvalues = adm.GetAdminListBL();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adm.AdminAddBL(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            //KATEGORİLER DROPDOWNA TAŞIMA
            List<SelectListItem> valuerole = adm.GetAdminListBL()
     .Select(y => new SelectListItem
     {
         Text = y.AdminRole,
         Value = y.AdminRole
    })
     .ToList();
            ViewBag.vlc = valuerole;
            var adminvalue = adm.GetByIDBL(id);
            return View("UpdateAdmin", adminvalue);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            adm.AdminUpdateBL(admin);
            return RedirectToAction("Index");
        }

    }
}