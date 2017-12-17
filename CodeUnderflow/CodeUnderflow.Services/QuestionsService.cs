using CodeUnderflow.Common.Extensions;
using CodeUnderflow.Data.Models;
using CodeUnderflow.Services.Contracts;
using CodeUnderflow.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeUnderflow.Services.Models.Questions;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace CodeUnderflow.Services
{
    public class QuestionsService : IQuestionsService
    {
        private CodeUnderflowDbContext db;

        public QuestionsService(CodeUnderflowDbContext db)
        {
            this.db = db;
        }

        public int CreateNew(string title, string content, string tags, DateTime postDate, string userId)
        {
            var question = new Question()
            {
                Title = title,
                Content = content,
                PostDate = postDate,
                AuthorId = userId
            };

            this.LoadCreateTags(question, tags);

            this.db.Questions.Add(question);
            this.db.SaveChanges();

            return question.Id;
        }



        public bool Exists(int questionId)
        {
            return this.db.Questions.Any(q => q.Id == questionId);
        }

        public QuestionDetailsModel GetDetails(int questionId)
        {
            var model = this.db.Questions.Where(q => q.Id == questionId)
                .ProjectTo<QuestionDetailsModel>().FirstOrDefault();

            return model;
        }

        public QuestionEditModel GetEditInfo(int questionId)
        {
            var model = this.db.Questions.Where(q => q.Id == questionId).ProjectTo<QuestionEditModel>().FirstOrDefault();

            return model;
        }

        public bool IsAuthor(int questionId, string userId)
        {
            return this.db.Questions.Where(q => q.Id == questionId && q.AuthorId == userId).Count() > 0;
        }

        public void Update(int questionId, string title, string content, string tags, DateTime editDate)
        {
            var question = this.db.Questions.First(q => q.Id == questionId);
            question.Title = title;
            question.Content = content;
            question.EditDate = editDate;

            this.db.Entry(question).Collection(q => q.Tags).Load();
            foreach (var tag in question.Tags)
            {
                this.db.Entry(tag).Reference(t => t.Tag).Load();
            }

            this.UpdateTags(question, tags);

            this.db.SaveChanges();

        }

        private void UpdateTags(Question question, string tags)
        {
            var tagTitles = tags.SplitAndFilterTagTitles();

            var tagsToRemove = new Stack<QuestionTag>();
            foreach (var existingTag in question.Tags)
            {
                if (!tagTitles.Any(t => t.Equals(existingTag.Tag.Title, StringComparison.InvariantCultureIgnoreCase)))
                {
                    tagsToRemove.Push(existingTag);
                }
            }

            while (tagsToRemove.Any())
            {
                question.Tags.Remove(tagsToRemove.Pop());
            }

            var existingTags = question.Tags.Select(t => t.Tag.Title).ToList();

            tagTitles = tagTitles.Where(t => !existingTags.Contains(t)).ToList();

            tags = string.Join(" ", tagTitles);

            LoadCreateTags(question, tags);
        }

        private void LoadCreateTags(Question question, string tags)
        {
            var tagTitles = tags.SplitAndFilterTagTitles();
            foreach (var tagTitle in tagTitles)
            {
                var tag = this.db.Tags.FirstOrDefault(t => t.Title == tagTitle);

                if (tag is null)
                {
                    tag = new Tag()
                    {
                        Title = tagTitle
                    };
                }

                question.Tags.Add(new QuestionTag()
                {
                    Tag = tag
                });
            }
        }

        public void Delete(int questionId)
        {
            var question = this.db.Questions.First(q => q.Id == questionId);

            this.db.Questions.Remove(question);

            this.db.SaveChanges();
        }

        public int RegisterVote(int questionId, string userId)
        {
            var question = this.db.Questions.Include(q => q.Votes).First(q => q.Id == questionId);

            Vote vote = null;

            if (question.Votes.Any(v => v.UserId == userId))
            {
                vote = question.Votes.First(v => v.UserId == userId);

                question.Votes.Remove(vote);
            }
            else
            {
                vote = new Vote()
                {
                    UserId = userId
                };

                question.Votes.Add(vote);
            }

            this.db.SaveChanges();

            return question.Votes.Count;
        }

        public bool UserHasStared(int questionId, string userId)
        {
            return this.db.Questions.Include(q => q.Votes).Where(q => q.Id == questionId).First().Votes.Any(v => v.UserId == userId);
        }

        public IEnumerable<QuestionInfoModel> GetLatestQuestion()
        {
            var latestQuestions = this.db.Questions.Include(q => q.Tags).OrderByDescending(q => q.PostDate).ProjectTo<QuestionInfoModel>().ToList();

            return latestQuestions;
        }
    }
}