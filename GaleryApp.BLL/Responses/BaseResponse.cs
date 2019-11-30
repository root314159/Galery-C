using GaleryApp.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.BLL.Responses
{
    public class BaseResponse
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public void SetState(Constants.ERROR_ENUMS code)
        {
            this.Code = (int)code;
            this.Message = Constants.ERROR_CODES[(int)code];

        }
    }
}
