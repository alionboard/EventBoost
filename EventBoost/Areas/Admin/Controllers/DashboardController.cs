﻿using EventBoost.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBoost.Areas.Admin.Controllers
{
    
    public class DashboardController : AdminBaseController
    {
        public DashboardController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
