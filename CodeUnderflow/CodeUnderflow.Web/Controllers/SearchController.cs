using CodeUnderflow.Services.Contracts;
using CodeUnderflow.Services.Models.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Web.Controllers
{
    public class SearchController : Controller
    {
        private ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult Query(string searchTerm)
        {
            List<SearchMatchModel> results = new List<SearchMatchModel>();

            if (searchTerm != null && searchTerm.Trim().Length >= 2)
            {
                results = this.searchService.GetMatchingQuestions(searchTerm.Trim());
            }

            return Ok(results);
        }
    }
}