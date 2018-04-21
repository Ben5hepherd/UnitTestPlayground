using Machine.Fakes;
using Machine.Specifications;
using System.Collections.Generic;
using System.Linq;
using UnitTestPlayground.CommandQuery.Queries;
using UnitTestPlayground.Domain.Entities;
using UnitTestPlayground.Orm.EntityFramework;

namespace UnitTestPlayground.Tests.Queries
{
    [Subject(typeof(GetAllUsersQuery))]
    public class When_getting_all_users : WithSubject<GetAllUsersQuery>
    {
        static IList<User> result;
        static DataContext dataContext;

        Establish context = () =>
        {
            using (var connection = Effort.DbConnectionFactory.CreateTransient())
            {
                dataContext = new TestDataContext(connection);
                Configure<IDataContext>(dataContext);

                dataContext.Users.Add(new User { Age = 23, Name = "Test" });
                dataContext.SaveChanges();
            }
        };

        Because of = () => result = Subject.Execute();

        It should_return_the_correct_number_of_users = () => result.Count.ShouldEqual(1);

        It should_return_the_correct_user = () =>
        {
            var user = result.First();
            user.Name.ShouldEqual("Test");
            user.Age.ShouldEqual(23);
        };
    }
}