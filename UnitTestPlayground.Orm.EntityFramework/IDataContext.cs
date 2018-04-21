using System.Data.Entity;
using UnitTestPlayground.Domain.Entities;

namespace UnitTestPlayground.Orm.EntityFramework
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}