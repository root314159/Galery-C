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
        // GET: Account
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult RegisterPage()
        {
            return View();
        }
 
        [HttpPost]
        public ActionResult HomePage(User user)
        {
            UserPhotoModel model = new UserPhotoModel();
            AccountService service = new AccountService();
            LoginResponse response = service.Login(user.Name, user.Password);
            model.User = response.User;
            Session["model"] = model;
            if(response.Code == (int)Constants.ERROR_ENUMS.SUCCESS)
            {
                
                return RedirectToAction("PhotoPage", "Galery");

            }
            return View(model);
        }
    }
}