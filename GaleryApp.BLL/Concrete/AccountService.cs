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
    public class AccountService : IAccountService
    {

        //user deposu
        private IEFRepository<User> _userRepo;
        private IUnitOfWork _unitOfWork;
        public User _user;


        public AccountService()
        {
            GaleryContext galeryContext = new GaleryContext();
            _unitOfWork = new EFUnitOfWork(galeryContext);
            _userRepo = new EFRepository<User>(galeryContext);

        }

        public LoginResponse Login(string userName, string password)
        {

            LoginResponse response = new LoginResponse();

            try
            {
                User user = _userRepo.Get(t => t.Name == userName && t.Password == password).FirstOrDefault();

                if (user == null)
                {
                    response.SetState(Common.Constants.ERROR_ENUMS.INVALID_USERNAME_OR_PASSWORD);
                    return response;

                }

                //string _token = DateTime.Now.Ticks.ToString();
                //user.Tokens.Add(new Token
                //{
                //    TokenText = _token,
                //    IsDeleted = false
                //});

                //int result = _unitOfWork.SaveChanges();

                //if (result == 0)
                //{
                //    response.SetError(Common.Constants.ERROR_ENUMS.SYSTEM);
                //    return response;
                //}

                //response.UserName = user.Name;
                //response.Token = _token;
                response.User = user;

            }
            catch (Exception ex)
            {
                //hatayı loglamam lazım
                
                response.SetState(Common.Constants.ERROR_ENUMS.SYSTEM);
                //return response;
                throw ex;

            }


            response.SetState(Common.Constants.ERROR_ENUMS.SUCCESS);
            return response;
        }
    }
}
