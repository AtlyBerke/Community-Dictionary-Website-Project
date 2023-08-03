using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterMessageController : Controller
    {
        MessageManager mg = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        

        public ActionResult Index(string p)
        {
            p = (string)Session["WriterMail"];
            var messagelist = mg.GetInboxMessageListBL(p);
            return View(messagelist);
        }

        public PartialViewResult SideBar(string p)
        {
            p = (string)Session["WriterMail"];
            Context c = new Context();
            //GELEN MESAJLAR
            var inboxmessage = c.Messages.Where(x => x.ReceiverMail == p).Count();
            ViewBag.inbox = inboxmessage;
            //GÖNDERİLEN MESAJLAR
            var sendboxmessage = c.Messages.Where(x => x.SenderMail == p).Count();
            ViewBag.sendbox = sendboxmessage;
            return PartialView();
        }

        public ActionResult Sendbox(string p)
        {
            p = (string)Session["WriterMail"];
            var messagelist = mg.GetSendboxMessageListBL(p);
            return View(messagelist);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var inboxvalues = mg.GetByIDBL(id);
            return View("GetInboxMessageDetails", inboxvalues);
        }

        [HttpGet]
        public ActionResult NewMessageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessageAdd(Message message)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = mv.Validate(message); //writervalidator sınıfında olan değerlere göre writer nesnesini validate(kontrol) et.
            if (results.IsValid)
            {
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mg.MessageAddBL(message);
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