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
        public IActionResult Index(string query)
        {
            return Ok(query);
        }
    }
}