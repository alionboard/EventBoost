﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventBoost.Areas.Admin.Models
{
    public class NewMeetingViewModel
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        public string Description { get; set; }
        public DateTime? MeetingTime { get; set; }
        public string Place { get; set; }
        public IFormFile Photo { get; set; }
    }
}
