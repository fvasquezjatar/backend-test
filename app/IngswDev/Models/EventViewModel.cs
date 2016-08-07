using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IngswDev.Models
{
    public class EventViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public bool Highlight { get; set; }
        [Required]
        public string ImageUri { get; set; }
        [Display(Name = "Target Dates")]
        public List<DateTime> TargetDates { get; set; }
    }
}
