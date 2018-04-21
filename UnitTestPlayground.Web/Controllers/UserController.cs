using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using UnitTestPlayground.CommandQuery.Models;
using UnitTestPlayground.CommandQuery.Queries.Interfaces;
using UnitTestPlayground.Domain.Entities;

namespace UnitTestPlayground.Web.Controllers
{
    public class UserController : ApiController
    {
        readonly IGetAllUsersQuery getAllUsersQuery;

        public UserController(IGetAllUsersQuery getAllUsersQuery)
        {
            this.getAllUsersQuery = getAllUsersQuery;
        }

        public IEnumerable<User> Get()
        {
            return getAllUsersQuery.Execute();
        }

        public void Post(AddUserModel model)
        {
            if (!ModelState.IsValid)
                throw new ValidationException();

            //Add the user
        }
    }
}