using CodeUnderflow.Services.Contracts;
using CodeUnderflow.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodeUnderflow.Services
{
    public class TagService : ITagService
    {
        private CodeUnderflowDbContext db;

        public TagService(CodeUnderflowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<string> GetPopularTags(int countToTake)
        {
            return this.db.Tags.OrderByDescending(t => t.Questions.Count).Take(countToTake).Select(t => t.Title).ToList();
        }

        public IEnumerable<string> GetSimilarTags(IEnumerable<string> tags, int count)
        {
            var result = this.db
                .Questions.Include(q => q.Tags)
                .Where(q => q.Tags.Select(qt => qt.Tag.Title).Any(t => tags.Contains(t)))
                .Select(q => q.Tags.Select(t => t.Tag.Title))
                .SelectMany(t => t)
                .Distinct()
                .Take(count)
                .ToList();

            return result;
        }
    }
}