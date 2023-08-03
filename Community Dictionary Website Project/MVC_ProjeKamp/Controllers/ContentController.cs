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
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        // GET: Content
        public ActionResult Index()
        {
            var contentvalues = cm.GetContentListBL();
            return View(contentvalues);
        }

        public ActionResult GetAllContent(string p)
        {
            if (p==null)
            {
               var values2=cm.GetContentListBL();
                return View(values2);
            }
            var values = cm.GetSearchList(p);
            return View(values);
        }

        public ActionResult ContentbyHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }

  
    }
}