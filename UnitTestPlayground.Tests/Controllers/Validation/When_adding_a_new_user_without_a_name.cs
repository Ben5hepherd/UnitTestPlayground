using Machine.Fakes;
using Machine.Specifications;
using System.ComponentModel.DataAnnotations;
using UnitTestPlayground.CommandQuery.Models;
using UnitTestPlayground.Tests.Helpers;
using UnitTestPlayground.Web.Controllers;

namespace UnitTestPlayground.Tests.Controllers.Validation
{
    [Subject(typeof(UserController))]
    public class When_adding_a_new_user_without_a_name : WithSubject<UserController>
    {
        static ValidationException exception;
        static AddUserModel model;

        Establish context = () => model = new AddUserModel { Name = null, Age = 20 };

        Because of = () => exception = (ValidationException)Catch.Exception(() =>
        {
            Subject.ValidateModel(model);
            Subject.Post(model);
        });

        It should_throw_a_validation_exception = () => exception.ShouldBeOfExactType<ValidationException>();
    }
}