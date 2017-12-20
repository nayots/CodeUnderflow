using CodeUnderflow.Services.Models.Questions;
using CodeUnderflow.Services.Models.Search;
using System.Collections.Generic;

namespace CodeUnderflow.Services.Contracts
{
    public interface ISearchService
    {
        List<SearchMatchModel> GetMatchingQuestions(string searchTerm = "");

        IEnumerable<QuestionInfoModel> GetResults(bool isTagSearch, string searchTerm = "");
    }
}