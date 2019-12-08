using GaleryApp.BLL.Common;
using GaleryApp.BLL.Concrete;
using GaleryApp.BLL.Responses;
using GaleryApp.Core.DomainClasses;
using GaleryApp.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GaleryApp.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult HomePage()
        {
            return View();
        }
        // GET: Account
        [HttpPost]
        public ActionResult HomePage(string Name, string Password)
        {
            UserPhotoModel model = new UserPhotoModel();
            AccountService service = new AccountService();
            LoginResponse response = service.Login(Name, Password);
            model.User = response.User;
            Session["model"] = model;
            if(response.Code == (int)Constants.ERROR_ENUMS.SUCCESS)
            {
                
                return RedirectToAction("PhotoPage", "Galery");

            }
            if (model.User == null)
            {
                model.User = new User();
                return View(model.User);
            }
            return View();
        }
    }
}