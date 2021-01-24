using EventBoost.Areas.Admin.Models;
using EventBoost.Data;
using EventBoost.Models;
using EventBoost.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventBoost.Areas.Admin.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class EventsController : AdminBaseController
    {
        public EventsController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IActionResult Index()
        {
            return View(_db.Meetings.ToList());
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(NewMeetingViewModel vm, [FromServices] IWebHostEnvironment env)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-5.0


            if (ModelState.IsValid)
            {
            string fileName = null;
                if (vm.Photo != null && vm.Photo.Length > 0)
                {
                    fileName = vm.Photo.GenerateFileName();
                    var savePath = Path.Combine(env.WebRootPath,"img",fileName);
                    vm.Photo.CopyTo(new FileStream(savePath, FileMode.Create));
                }
                var meeting = new Meeting()
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    MeetingTime = vm.MeetingTime,
                    Place = vm.Place,
                    PhotoPath=fileName
                };
                _db.Add(meeting);
                _db.SaveChanges();
            }

            return View();
        }
    }
}
