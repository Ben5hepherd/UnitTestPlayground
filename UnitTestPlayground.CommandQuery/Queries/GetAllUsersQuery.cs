using System.Collections.Generic;
using System.Linq;
using UnitTestPlayground.Domain.Entities;
using UnitTestPlayground.Orm.EntityFramework;

namespace UnitTestPlayground.CommandQuery.Queries
{
    public class GetAllUsersQuery
    {
        readonly IDataContext dataContext;

        public GetAllUsersQuery(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IList<User> Execute() => dataContext.Users.ToList();
    }
}