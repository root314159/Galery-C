using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.Core.DomainClasses
{
    public class BaseEntity
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="bu alan gerekli")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
