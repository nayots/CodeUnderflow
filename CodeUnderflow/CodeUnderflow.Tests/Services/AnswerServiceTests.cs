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

namespace CodeUnderflow.Tests.Services
{
    public class AnswerServiceTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void CreateAnswerSavesItToDatabase(int questionId)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            var sut = new AnswersService(db);

            //Act
            sut.Create(questionId, "asd", "test", DateTime.UtcNow);

            //Assert
            Assert.True(db.Answers.Any(a => a.QuestionId == questionId));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void DeleteAnswerRemovesItFromDb(int answerId)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new AnswersService(db);

            //Act
            sut.Delete(answerId);
            //Assert
            Assert.True(!db.Answers.Any(a => a.Id == answerId));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void AnswerExists(int answerId)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new AnswersService(db);

            //Act
            //Assert
            Assert.True(sut.Exists(answerId));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void AnswerHasCorrectContent(int id)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new AnswersService(db);

            //Act
            var content = sut.GetAnswerContent(id);

            //Assert
            Assert.True(content == $"Content{id}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void UpdateAnswerContent(int id)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new AnswersService(db);

            //Act
            sut.Update(id, $"NewContent{id}");

            //Assert
            Assert.True(db.Answers.First(a => a.Id == id).Content == $"NewContent{id}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void ReturnTrueThatUserIfUserCanEdit(int id)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new AnswersService(db);

            //Act
            var canEdit = sut.UserCanEdit(id, $"asd{id}");

            //Assert
            Assert.True(canEdit);
        }

        private void PopulateDb(CodeUnderflowDbContext db)
        {
            db.Answers.Add(new Answer()
            {
                Id = 1,
                Content = "Content1",
                QuestionId = 11,
                AuthorId = "asd1",
                PostDate = DateTime.UtcNow,
                Votes = 10
            });

            db.Answers.Add(new Answer()
            {
                Id = 2,
                Content = "Content2",
                QuestionId = 12,
                AuthorId = "asd2",
                PostDate = DateTime.UtcNow,
                Votes = 12
            });
            db.Answers.Add(new Answer()
            {
                Id = 3,
                Content = "Content3",
                QuestionId = 13,
                AuthorId = "asd3",
                PostDate = DateTime.UtcNow,
                Votes = 13
            });
            db.Answers.Add(new Answer()
            {
                Id = 4,
                Content = "Content4",
                QuestionId = 14,
                AuthorId = "asd4",
                PostDate = DateTime.UtcNow,
                Votes = 14
            });

            db.Answers.Add(new Answer()
            {
                Id = 5,
                Content = "Content5",
                QuestionId = 15,
                AuthorId = "asd5",
                PostDate = DateTime.UtcNow,
                Votes = 15
            });
            db.Answers.Add(new Answer()
            {
                Id = 6,
                Content = "Content6",
                QuestionId = 16,
                AuthorId = "asd6",
                PostDate = DateTime.UtcNow,
                Votes = 16
            });

            db.SaveChanges();
        }
    }
}
