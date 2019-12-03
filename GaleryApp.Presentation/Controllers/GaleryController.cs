using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GaleryApp.BLL.Common;
using GaleryApp.BLL.Concrete;
using GaleryApp.BLL.Responses;
using GaleryApp.Core.DomainClasses;
using GaleryApp.Presentation.Models;

namespace GaleryApp.Presentation.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery

        public ActionResult PhotoPage()
        {
            
            PhotoService photoService = new PhotoService();
            UserPhotoModel model = (UserPhotoModel)Session["model"];
            PhotoResponse photoResponse = photoService.GetPhotos(model.User);
            model.Photos = photoResponse.Photos;
            
            if (photoResponse.Code ==(int)Constants.ERROR_ENUMS.SUCCESS)
            {
                
                return View(model);
            }
            return View();
        }
    }
}