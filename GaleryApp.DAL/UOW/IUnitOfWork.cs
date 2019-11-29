using GaleryApp.Core.DomainClasses;
using GaleryApp.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.DAL.UOW
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        IEFRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}
