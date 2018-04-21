using System.Data.Common;
using UnitTestPlayground.Orm.EntityFramework;

namespace UnitTestPlayground.Tests
{
    public class TestDataContext : DataContext
    {
        public TestDataContext(DbConnection connection)
            : base(connection)
        {

        }
    }
}