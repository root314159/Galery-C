using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GaleryApp.BLL.Common;
using GaleryApp.BLL.Concrete;
using GaleryApp.BLL.Responses;
using GaleryApp.Presentation.Models;

namespace GaleryApp.Presentation.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        public ActionResult PhotoPage()
        {

            return View();
        }
        public ActionResult HomePage()
        {
           
            return View();
        }
        public ActionResult AboutMe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HomePage(string name, string password)
        {
            UserPhotoModel model = new UserPhotoModel();
            AccountService service = new AccountService();
            LoginResponse response = service.Login(name, password);
            model.User = response.User;

            PhotoService photoService = new PhotoService();
            PhotoResponse photoResponse = photoService.GetPhotos(response.User);
            model.Photos = photoResponse.Photos;
            if (response.Code ==(int)Constants.ERROR_ENUMS.SUCCESS)
            {
                //ViewBag.Message = "Success";
                return View(model);
            }
            return View();
        }
    }
}