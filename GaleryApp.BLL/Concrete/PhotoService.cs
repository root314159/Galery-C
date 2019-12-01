using GaleryApp.BLL.Abstract;
using GaleryApp.BLL.Responses;
using GaleryApp.Core.DomainClasses;
using GaleryApp.DAL.Data;
using GaleryApp.DAL.Repository;
using GaleryApp.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.BLL.Concrete
{
    public class PhotoService : IPhotoService
    {

        private IEFRepository<Photo> _photoRepo;
        private IUnitOfWork _unitOfWork;
        public PhotoService()
        {
            GaleryContext galeryContext = new GaleryContext();
            _unitOfWork = new EFUnitOfWork(galeryContext);
            _photoRepo = new EFRepository<Photo>(galeryContext);
        }

        public PhotoResponse GetPhotos(User user)
        {
            PhotoResponse response = new PhotoResponse();
            try
            {
                List<Photo> photos = _photoRepo.Get(t => t.UserID == user.ID).ToList();
                if (photos == null)
                {
                    response.SetState(Common.Constants.ERROR_ENUMS.NO_RECORD);
                    return response;
                }
                response.Photos = photos;
            }
            catch(Exception ex)
            {
                //hatayı loglamam lazım

                response.SetState(Common.Constants.ERROR_ENUMS.SYSTEM);
                return response;
                //throw ex;
            }
            response.SetState(Common.Constants.ERROR_ENUMS.SUCCESS);
            return response;
        }
    }
}
