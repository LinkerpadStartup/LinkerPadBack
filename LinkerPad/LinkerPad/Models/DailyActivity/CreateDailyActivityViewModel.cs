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