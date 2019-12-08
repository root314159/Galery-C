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
        
        public ActionResult PhotoPage(int? page)
        {
            
            PhotoService photoService = new PhotoService();

            UserPhotoModel model = (UserPhotoModel)Session["model"];
            if (page == null)
            {
                PhotoResponse photoResponse = photoService.GetPhotos(model.User);
                model.Photos = photoResponse.Photos;
            }
            else
            {
                PhotoResponse photoResponse = photoService.GetPhotosPartByPart(model.User, (int)page);
                model.Photos = photoResponse.Photos;
            }
            return View(model);


        }

    }
}