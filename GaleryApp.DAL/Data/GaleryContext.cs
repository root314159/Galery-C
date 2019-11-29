using GaleryApp.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleryApp.DAL.Data
{
    public class GaleryContext :DbContext
    {
        public GaleryContext() : base("name=conString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(t => t.Photos).WithRequired(t => t.User).HasForeignKey(t => t.UserID);
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
    }
}
