using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.DailyActivity
{
    public class CreateDailyActivityViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string WorkloadUnit { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int NumberOfCrew { get; set; }

        public float WorkHours { get; set; }

        public float Workload { get; set; }

        public static DailyActivityData GetDailyActivityData(Guid userId, CreateDailyActivityViewModel createDailyActivityViewModel)
        {
            return new DailyActivityData
            {
                ProjectData = new ProjectData
                {
                    Id = createDailyActivityViewModel.ProjectId
                },
                CreatedBy = new UserData
                {
                    Id = userId
                },
                ReportDate = createDailyActivityViewModel.ReportDate,
                Title = createDailyActivityViewModel.Title,
                WorkloadUnit = createDailyActivityViewModel.WorkloadUnit,
                Description = createDailyActivityViewModel.Description,
                NumberOfCrew = createDailyActivityViewModel.NumberOfCrew,
                WorkHours = createDailyActivityViewModel.WorkHours,
                Workload = createDailyActivityViewModel.Workload,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}