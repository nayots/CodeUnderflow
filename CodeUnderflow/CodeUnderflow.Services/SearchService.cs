using CodeUnderflow.Services.Contracts;
using CodeUnderflow.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeUnderflow.Services.Models.Search;
using AutoMapper.QueryableExtensions;
using CodeUnderflow.Services.Models.Questions;
using Microsoft.EntityFrameworkCore;

namespace CodeUnderflow.Services
{
    public class SearchService : ISearchService
    {
        private CodeUnderflowDbContext db;

        public SearchService(CodeUnderflowDbContext db)
        {
            this.db = db;
        }

        public List<SearchMatchModel> GetMatchingQuestions(string searchTerm = "")
        {
            return this.db.Questions
                .Where(q => q.Title.Contains(searchTerm) && q.IsArchived == false)
                .OrderByDescending(q => q.Votes.Count)
                .ProjectTo<SearchMatchModel>().ToList();
        }

        public IEnumerable<QuestionInfoModel> GetResults(bool isTagSearch,string searchTerm = "")
        {
            var results = new List<QuestionInfoModel>();

            if (isTagSearch)
            {
                results = this.db.Questions
                    .Include(q => q.Tags)
                    .Where(q => q.Tags.Any(t => t.Tag.Title == searchTerm))
                    .ProjectTo<QuestionInfoModel>().ToList();
            }
            else
            {
                results = this.db.Questions
                    .Where(q => q.Title.Contains(searchTerm))
                    .ProjectTo<QuestionInfoModel>().ToList();
            }

            return results;
        }
    }
}
