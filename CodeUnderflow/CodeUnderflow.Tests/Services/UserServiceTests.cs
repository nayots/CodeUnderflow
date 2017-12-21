using CodeUnderflow.Web.Data;
using CodeUnderflow.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CodeUnderflow.Services;
using CodeUnderflow.Data.Models;
using Moq;
using Microsoft.AspNetCore.Identity;

namespace CodeUnderflow.Tests.Services
{
    public class UserServiceTests
    {
        [Theory]
        [InlineData("user3")]
        [InlineData("user4")]
        public void SuspendUser(string userId)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new UserService(db, null, null);

            //Act
            sut.ReinstateUser(userId);

            //Assert
            Assert.True(!db.Users.First(u => u.Id == userId).IsDeleted);
        }

        [Theory]
        [InlineData("user1")]
        [InlineData("user2")]
        public void CheckIfUserIsNotDeleted(string userId)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new UserService(db, null, null);

            //Act
            var isDeleted = sut.CheckIfDeleted(userId);

            //Assert
            Assert.True(!isDeleted);
        }

        [Theory]
        [InlineData("user1")]
        [InlineData("user2")]
        [InlineData("user3")]
        [InlineData("user4")]
        public void CheckIfUserExistsByUserId(string userId)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new UserService(db, null, null);

            //Act
            var exists = sut.UserExistsById(userId);

            //Assert
            Assert.True(exists);
        }

        private void PopulateDb(CodeUnderflowDbContext db)
        {
            db.Users.Add(new User()
            {
                Id = "user1"
            });
            db.Users.Add(new User()
            {
                Id = "user2"
            });
            db.Users.Add(new User()
            {
                Id = "user3",
                IsDeleted = true
            });
            db.Users.Add(new User()
            {
                Id = "user4",
                IsDeleted = true
            });

            db.SaveChanges();
        }
    }

}
