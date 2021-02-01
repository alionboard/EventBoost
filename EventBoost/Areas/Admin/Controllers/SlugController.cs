using EventBoost.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBoost.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class SlugController : Controller
    {
        [HttpPost]
        public string Generate(string text)
        {
            return WebUtilities.URLFriendly(text);
        }
    }
}
