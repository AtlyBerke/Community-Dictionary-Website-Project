using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
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
    public class UserWriterContentController : Controller
    {

        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();

        public ActionResult MyContent(string p)
        {
           
            p = (string)Session["WriterMail"]; //Session bize sisteme entegre olduktan sonra o veriyi taşımamızı sağlar.
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentvalues = cm.GetListByWriterID(writeridinfo);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContentByWriter(int id)
        {
            ViewBag.id = id;
            return View();
        }


        [HttpPost]
        public ActionResult AddContentByWriter(Content content)
        {
            
            string p = (string)Session["WriterMail"]; //Session bize sisteme entegre olduktan sonra o veriyi taşımamızı sağlar.
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Today;
            content.WriterID = writeridinfo;
            content.ContentStatus = true;
            cm.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}