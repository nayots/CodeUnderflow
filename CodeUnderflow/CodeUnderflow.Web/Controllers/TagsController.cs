using CodeUnderflow.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Web.Controllers
{
    public class TagsController : Controller
    {
        private ITagService tagService;

        public TagsController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        public IActionResult Index()
        {
            var popularTags = this.tagService.GetPopularTags(20);

            return View(popularTags);
        }
    }
}
