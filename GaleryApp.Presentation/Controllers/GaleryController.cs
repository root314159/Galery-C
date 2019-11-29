using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GaleryApp.Presentation.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        public ActionResult AboutMe()
        {
            return View();
        }
    }
}