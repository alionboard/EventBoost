using EventBoost.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBoost.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MeetingsController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#ar
        [Route("meetings/{id:int}/{slug}")]
        public IActionResult Index(int id, string slug)
        {
            var meeting = _db.Meetings.Find(id);

            if (meeting == null)
            {
                return NotFound();
            }

            if (meeting.Slug != slug)
            {
                return RedirectToAction("Details", new { id = id, slug = meeting.Slug });
            }

            return View(meeting);
        }
    }
}
