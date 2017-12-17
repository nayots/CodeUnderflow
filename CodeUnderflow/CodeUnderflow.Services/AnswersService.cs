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

        public void Delete(int answerId)
        {
            var answer = this.db.Answers.First(a => a.Id == answerId);

            this.db.Answers.Remove(answer);
            this.db.SaveChanges();
        }

        public bool Exists(int answerId)
        {
            return this.db.Answers.Any(a => a.Id == answerId);
        }

        public string GetAnswerContent(int answerId)
        {
            return this.db.Answers.Where(a => a.Id == answerId).Select(a => a.Content).First();
        }

        public void Update(int answerId, string content)
        {
            var answer = this.db.Answers.First(a => a.Id == answerId);

            answer.Content = content;

            this.db.SaveChanges();
        }

        public bool UserCanEdit(int anwerId, string userId)
        {
            return this.db.Answers.Where(a => a.Id == anwerId && a.AuthorId == userId).Count() > 0;
        }
    }
}
