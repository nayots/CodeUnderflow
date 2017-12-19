using CodeUnderflow.Common;
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

        [HttpGet]
        public IActionResult Search(SearchResultModel searchResultModel)
        {
            searchResultModel.SearchTerm = searchResultModel.SearchTerm is null ? "" : searchResultModel.SearchTerm;
            searchResultModel.Results = this.searchService.GetResults(searchResultModel.IsTagSearch, searchResultModel.SearchTerm.Trim());

            bool enablePagination = searchResultModel.Results.Count() > GlobalConstants.MaxItemsPerPage;

            this.ViewData["Pagination"] = enablePagination;

            if (enablePagination)
            {
                var page = searchResultModel.Page;

                var maxPages = (int)(Math.Ceiling(searchResultModel.Results.Count() / (double)GlobalConstants.MaxItemsPerPage));
                var currentPage = page < 0 ? 0 : page;
                currentPage = currentPage > maxPages ? maxPages - 1 : currentPage;

                searchResultModel.Results = searchResultModel.Results
                    .Skip((currentPage < 0 ? 0 : currentPage) * GlobalConstants.MaxItemsPerPage)
                    .Take((currentPage == 0 ? 1 : currentPage) * GlobalConstants.MaxItemsPerPage)
                    .ToList();

                this.ViewData["MaxPages"] = maxPages;
                this.ViewData["CurrentPage"] = currentPage;
            }

            return this.View(searchResultModel);
        }
    }
}