using Keezag.Domain.Context.Entities;
using Keezag.Domain.Context.Interfaces;
using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using Keezag.Domain.Context.Services;
using Keezag.Infrastructure.Repositories;

namespace Keezag.Tests
{
    [TestFixture]
    public class UserTest
    {
        private UserValidationWithoutDatabase validator;
     
        [SetUp]
        public void Setup()
        {
            validator = new UserValidationWithoutDatabase();
        }

        [Test]
        public void UserInValid()
        {
            User user = new User()
            {
                Email = "wevertonsv@gmail.com"
            };
            Assert.IsFalse(validator.Validate(user).IsValid);
        }
    }
}