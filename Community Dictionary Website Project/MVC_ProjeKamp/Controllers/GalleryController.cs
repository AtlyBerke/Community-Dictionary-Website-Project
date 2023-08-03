using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    public class GalleryController : Controller
    {

        ImageManager ım = new ImageManager(new EfImageDal());

        public ActionResult Index()
        {
            //LIST
            var ımagevalues = ım.GetList();
            return View(ımagevalues);
        }
    }
}