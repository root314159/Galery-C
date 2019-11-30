using GaleryApp.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.BLL.Responses
{
    public class PhotoResponse:BaseResponse
    {
        public List<Photo> Photos { get; set; }
    }
}
