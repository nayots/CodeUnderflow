using CodeUnderflow.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    public abstract class BaseController : Controller
    {
        
    }
}
