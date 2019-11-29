using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.Core.DomainClasses
{
    public class Photo : BaseEntity
    {
        public int UserID { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }
    }
}
