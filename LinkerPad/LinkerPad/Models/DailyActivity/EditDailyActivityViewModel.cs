﻿using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.DailyActivity
{
    public class EditDailyActivityViewModel
    {
        [Required]
        public Guid DailyActivityId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string WorkloadUnit { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int NumberOfCrew { get; set; }

        [Required]
        public float WorkHours { get; set; }

        [Required]
        public float Workload { get; set; }

        public static DailyActivityData GetDailyActivityData(EditDailyActivityViewModel editDailyActivityViewModel)
        {
            return new DailyActivityData
            {
                Id = editDailyActivityViewModel.DailyActivityId,
                ProjectData = new ProjectData
                {
                    Id = editDailyActivityViewModel.ProjectId
                },
                ReportDate = editDailyActivityViewModel.ReportDate,
                Title = editDailyActivityViewModel.Title,
                WorkloadUnit = editDailyActivityViewModel.WorkloadUnit,
                Description = editDailyActivityViewModel.Description,
                NumberOfCrew = editDailyActivityViewModel.NumberOfCrew,
                WorkHours = editDailyActivityViewModel.WorkHours,
                Workload = editDailyActivityViewModel.Workload,
                ModifiedDate = DateTime.Now
            };
        }
    }
}