using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeUnderflow.Services.Models.Search;

namespace CodeUnderflow.Services.Contracts
{
    public interface ISearchService
    {
        List<SearchMatchModel> GetMatchingQuestions(string searchTerm = "");
    }
}
