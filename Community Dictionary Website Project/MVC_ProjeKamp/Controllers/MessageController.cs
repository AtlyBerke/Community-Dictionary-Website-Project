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
    public class MessageController : Controller
    {
        MessageManager mg = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        public ActionResult Index(string p)
        {
            p = (string)Session["AdminUserName"];
            var messagelist = mg.GetInboxMessageListBL(p);
            return View(messagelist);
        }

        public ActionResult Sendbox(string p)
        {
            p = (string)Session["AdminUserName"];
            var messagelist = mg.GetSendboxMessageListBL(p);
            return View(messagelist);
        }


        [HttpGet]
        public ActionResult NewMessageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessageAdd(Message message)
        {
            ValidationResult results = mv.Validate(message); //writervalidator sınıfında olan değerlere göre writer nesnesini validate(kontrol) et.
            if (results.IsValid)
            {
                message.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
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

        public ActionResult GetInboxMessageDetails(int id)
        {
            var inboxvalues = mg.GetByIDBL(id);
            return View("GetInboxMessageDetails",inboxvalues);
        }
    }
}