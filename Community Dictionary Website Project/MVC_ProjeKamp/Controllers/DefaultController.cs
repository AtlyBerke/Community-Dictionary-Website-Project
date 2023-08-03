using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{

    [AllowAnonymous]
    public class DefaultController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headingvalues = hm.GetHeadingList();
            return View(headingvalues);
        } 


        public PartialViewResult Index(int id=0)
        {
            var contentvaluesbyheading = cm.GetListByHeadingID(id);
            return PartialView(contentvaluesbyheading);
        }

       
    }
}