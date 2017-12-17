using CodeUnderflow.Data.Models;
using CodeUnderflow.Services.Contracts;
using CodeUnderflow.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Services
{
    public class AnswersService : IAnswersService
    {
        private CodeUnderflowDbContext db;

        public AnswersService(CodeUnderflowDbContext db)
        {
            this.db = db;
        }

        public void Create(int questionId, string userId, string content, DateTime postDate)
        {
            Answer answer = new Answer()
            {
                Content = content,
                AuthorId = userId,
                QuestionId = questionId,
                PostDate = postDate
            };

            this.db.Answers.Add(answer);
            this.db.SaveChanges();
        }
    }
}
