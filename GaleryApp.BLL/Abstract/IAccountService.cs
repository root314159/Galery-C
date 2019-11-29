using GaleryApp.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.BLL.Abstract
{
    public interface IAccountService
    {
        LoginResponse Login(string userName, string password);
    }
}
