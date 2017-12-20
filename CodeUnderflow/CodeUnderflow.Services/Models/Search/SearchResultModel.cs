using CodeUnderflow.Services.Models.Questions;
using System.Collections.Generic;

namespace CodeUnderflow.Services.Models.Search
{
    public class SearchResultModel
    {
        public string SearchTerm { get; set; }

        public int Page { get; set; }

        public bool IsTagSearch { get; set; }

        public IEnumerable<QuestionInfoModel> Results { get; set; } = new List<QuestionInfoModel>();
    }
}