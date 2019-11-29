using GaleryApp.Core.DomainClasses;
using GaleryApp.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.DAL.UOW
{
    public class EFUnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;
        public EFUnitOfWork(DbContext dbContext)
        {

            if (dbContext == null)
                throw new Exception("db context null");

            _dbContext = dbContext;

        }

        public IEFRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new EFRepository<T>(_dbContext);
        }

        public void Dispose()
        {
            try
            {
                _dbContext.Dispose();
            }
            catch (Exception)
            {


            }
        }

        public int SaveChanges()
        {


            return _dbContext.SaveChanges();
        }
    }
}
