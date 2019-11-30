using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GaleryApp.BLL.Common;
using GaleryApp.BLL.Concrete;
using GaleryApp.BLL.Responses;

namespace GaleryApp.Presentation.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult AboutMe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HomePage(string Name, string Password)
        {
            AccountService service = new AccountService();
            LoginResponse response = service.Login(Name, Password);
            if (response.Code ==(int)Constants.ERROR_ENUMS.SUCCESS)
            {
                //ViewBag.Message = "Success";
                return View(response.User);
            }
            return View();
        }
    }
}