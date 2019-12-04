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
                List<Photo> photos = _photoRepo.Get(t => t.UserID == user.ID).Take(3).ToList();
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
        public PhotoResponse GetPhotosPartByPart(User user, int page, int count=3)
        {
            PhotoResponse response = new PhotoResponse();
            int index = page * count;
            try
            {
                var photos = _photoRepo.Get().Where(t => t.UserID == user.ID).Take(index).ToList();
                if (photos == null)
                {
                    response.SetState(Common.Constants.ERROR_ENUMS.NO_RECORD);
                    return response;
                }
                response.Photos = photos;
            }
            catch(Exception ex)
            {
                response.SetState(Common.Constants.ERROR_ENUMS.SYSTEM);
                throw ex;
            }
            response.SetState(Common.Constants.ERROR_ENUMS.SUCCESS);
            return response;
        }
        /* 
        public ProductModelResponse GetProducts(GetProductRequest request)
        {
            ProductModelResponse productResponse = new ProductModelResponse();
            //page 2 count 10 için 
            //index=20 yani 20 den basla 10 tane getir.
            try
            {
                //ilk  20 elemanı gec sonrasındakı 10 taneyı al 
                //**eğer 10 tane yoksa 6 tane varsa 6 tanesi alınır.Hata vermez!!!!
                int index = (request.Page - 1) * request.Range;//dbde kac kayıt es gecılmeli
                var products = _repositoryProduct.Get().Where(t => request.CategoryID == 0 || t.CategoryID == request.CategoryID).Skip(index).Take(request.Range).ToList();

                foreach (Product item in products)
                {

                    ProductModel productModel = new ProductModel
                    {
                        ID = item.ID,
                        Description = item.Description,
                        Price = item.Price,
                        ProductImages = item.ProductImages.Select(t => t.URLFromAway).ToList(),
                        ProductName = item.ProductName
                    };
                    productResponse.Products.Add(productModel);
                }

                int allProductCount = _repositoryProduct.Get().Where(t => request.CategoryID == 0 || t.CategoryID == request.CategoryID).Count();
                productResponse.PagingInfo = new PagingInfo(request.Page, request.Range, allProductCount);
                productResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                return productResponse;
            }
            catch (Exception ex)
            {
                productResponse.Products = null;
                productResponse.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return productResponse;
            }
        }
         */
    }
}
