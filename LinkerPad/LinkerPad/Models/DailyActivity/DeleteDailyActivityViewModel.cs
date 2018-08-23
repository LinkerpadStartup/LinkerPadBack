using System;
using System.ComponentModel.DataAnnotations;

namespace LinkerPad.Models.DailyActivity
{
    public class DeleteDailyActivityViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid DailyActivityId { get; set; }
    }
}