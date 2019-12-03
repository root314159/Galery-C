using GaleryApp.BLL.Common;
using GaleryApp.BLL.Concrete;
using GaleryApp.BLL.Responses;
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
        public ActionResult HomePage(string name, string password)
        {
            UserPhotoModel model = new UserPhotoModel();
            AccountService service = new AccountService();
            LoginResponse response = service.Login(name, password);
            model.User = response.User;
            Session["model"] = model;
            if(response.Code == (int)Constants.ERROR_ENUMS.SUCCESS)
            {
                
                return RedirectToAction("PhotoPage", "Galery");

            }
            return View();
        }
    }
}