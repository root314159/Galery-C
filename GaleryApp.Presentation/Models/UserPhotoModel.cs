using GaleryApp.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaleryApp.Presentation.Models
{
    public class UserPhotoModel
    {
        public User User { get; set; }
        public List<Photo> Photos { get; set; }
        
    }
}