using System.Collections.Generic;
using UnitTestPlayground.Domain.Entities;

namespace UnitTestPlayground.CommandQuery.Queries.Interfaces
{
    public interface IGetAllUsersQuery
    {
        IList<User> Execute();
    }
}