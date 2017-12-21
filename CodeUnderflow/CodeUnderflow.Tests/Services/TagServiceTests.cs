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
    public class TagServiceTests
    {
        [Fact]
        public void GetPopularTagsReturnsValidCollection()
        {
            //Arrange
            TestUtils testUtils = new TestUtils();
            var db = testUtils.GetDbContext();
            this.PopulateDb(db);
            var sut = new TagService(db);

            //Act
            List<string> tags = sut.GetPopularTags(2).ToList();

            //Assert
            Assert.True(tags[0] == "Tag1");
            Assert.True(tags[1] == "Tag2");
        }

        private void PopulateDb(CodeUnderflowDbContext db)
        {
            db.Tags.Add(new Tag()
            {
                Title = "Tag1",
                Questions = new List<QuestionTag>()
                {
                    new QuestionTag()
                    {
                    },
                    new QuestionTag()
                    ,
                    new QuestionTag()
                }
            });

            db.Tags.Add(new Tag()
            {
                Title = "Tag2",
                Questions = new List<QuestionTag>()
                {
                    new QuestionTag()
                    ,
                    new QuestionTag()
                }
            });

            db.Tags.Add(new Tag()
            {
                Title = "Tag3",
                Questions = new List<QuestionTag>()
                {
                    new QuestionTag()
                }
            });

            db.SaveChanges();
        }
    }
}
