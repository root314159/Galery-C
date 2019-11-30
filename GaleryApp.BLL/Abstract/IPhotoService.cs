using GaleryApp.BLL.Responses;
using GaleryApp.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.BLL.Abstract
{
    interface IPhotoService
    {
        PhotoResponse GetPhotos(User user);
    }
}
