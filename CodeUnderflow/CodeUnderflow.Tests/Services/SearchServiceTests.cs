using CodeUnderflow.Data.Models;
using CodeUnderflow.Services;
using CodeUnderflow.Web.Data;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace CodeUnderflow.Tests.Services
{
    public class SearchServiceTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("Que")]
        public void GetCorrectNumberOfMatches(string searchTerm)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            TestUtils.InitializeMapper();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new SearchService(db);

            //Act
            var itemsFound = sut.GetMatchingQuestions(searchTerm).Count;

            //Assert
            Assert.True(searchTerm.Length == itemsFound);
        }

        [Theory]
        [InlineData(true, "Tag1", 3)]
        [InlineData(true, "Tag2", 2)]
        [InlineData(true, "Tag3", 1)]
        public void GetCorrectResultsFromTagSearch(bool isTagSearch, string keyword, int expected)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            TestUtils.InitializeMapper();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new SearchService(db);
            //Act
            var foundTagsResults = sut.GetResults(isTagSearch, keyword).Count();
            //Assert
            Assert.True(expected == foundTagsResults);
        }

        [Theory]
        [InlineData(false, "1", 1)]
        [InlineData(false, "2", 1)]
        [InlineData(false, "3", 1)]
        [InlineData(false, "Que", 3)]
        [InlineData(false, "stion", 3)]
        public void GetCorrectResultsFromNonTagSearch(bool isTagSearch, string keyword, int expected)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            TestUtils.InitializeMapper();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new SearchService(db);
            //Act
            var foundTagsResults = sut.GetResults(isTagSearch, keyword).Count();
            //Assert
            Assert.True(expected == foundTagsResults);
        }

        private void PopulateDb(CodeUnderflowDbContext db)
        {
            db.Questions.Add(new Question()
            {
                Title = "Question1",
                Votes = new List<Vote>()
                {
                    new Vote()
                },
                Tags = new List<QuestionTag>()
                {
                    new QuestionTag()
                    {
                        Tag = new Tag()
                        {
                            Title = "Tag1"
                        }
                    }
                }
            });
            db.Questions.Add(new Question()
            {
                Title = "Question2",
                Votes = new List<Vote>()
                {
                    new Vote()
                },
                Tags = new List<QuestionTag>()
                {
                    new QuestionTag()
                    {
                        Tag = new Tag()
                        {
                            Title = "Tag1"
                        }
                    },
                    new QuestionTag()
                    {
                        Tag = new Tag()
                        {
                            Title = "Tag2"
                        }
                    }
                }
            });
            db.Questions.Add(new Question()
            {
                Title = "Question3",
                Votes = new List<Vote>()
                {
                    new Vote()
                },
                Tags = new List<QuestionTag>()
                {
                    new QuestionTag()
                    {
                        Tag = new Tag()
                        {
                            Title = "Tag1"
                        }
                    },
                    new QuestionTag()
                    {
                        Tag = new Tag()
                        {
                            Title = "Tag2"
                        }
                    },
                    new QuestionTag()
                    {
                        Tag = new Tag()
                        {
                            Title = "Tag3"
                        }
                    }
                }
            });

            db.SaveChanges();
        }
    }
}