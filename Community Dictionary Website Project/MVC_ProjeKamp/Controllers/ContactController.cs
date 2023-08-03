using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalue = cm.GetByID(id);
            return View("GetContactDetails", contactvalue);
        }

        public PartialViewResult SideBar(string p)
        {
            p = (string)Session["AdminUserName"];
            Context c = new Context();
            //GELEN MESAJLAR
            var inboxmessage = c.Messages.Where(x => x.ReceiverMail == p).Count();
            ViewBag.inbox = inboxmessage;
            //GÖNDERİLEN MESAJLAR
            var sendboxmessage = c.Messages.Where(x => x.SenderMail == p).Count();
            ViewBag.sendbox = sendboxmessage;
            var communicationmessage = c.Contacts.Count();
            ViewBag.cmessage = communicationmessage;
            return PartialView();
        }
    }
}