using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.BLL.Common
{
    public class Constants
    {
        public enum ERROR_ENUMS
        {
            SUCCESS,
            INVALID_USERNAME_OR_PASSWORD,
            SYSTEM,
            NO_RECORD

        }

        public static Dictionary<int, string> ERROR_CODES = new Dictionary<int, string>
      {
          {0,"Success" },
          {1,"Username or password is invalid" },
          {2,"System error please call your manager!!" },
          {3,"There is no record." }
      };


    }
}
