using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UnitTestPlayground.Domain.Entities;
using UnitTestPlayground.Orm.EntityFramework.Configuration;

namespace UnitTestPlayground.Orm.EntityFramework
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext()
            : base("EntityFrameworkConnectionString")
        {
            Database.SetInitializer<DataContext>(null);
        }

        protected DataContext(DbConnection connection)
            : base(connection, true) { }

        public DbSet<User> Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add<ForeignKeyConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}