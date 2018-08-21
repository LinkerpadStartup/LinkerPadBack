using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.DailyTask
{
    public class CreateDailyTaskViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime DailyTaskDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string WorkloadUnit { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int CrewCount { get; set; }

        [Required]
        public int WorkHours { get; set; }

        [Required]
        public int Workload { get; set; }

        public static DailyTaskData GetDailyTaskData(Guid userId, CreateDailyTaskViewModel createDailyTaskViewModel)
        {
            return new DailyTaskData
            {
                ProjectData = new ProjectData
                {
                    Id = createDailyTaskViewModel.ProjectId
                },
                CreatedBy = new UserData
                {
                    Id = userId
                },
                DailyTaskDate = createDailyTaskViewModel.DailyTaskDate,
                Title = createDailyTaskViewModel.Title,
                WorkloadUnit = createDailyTaskViewModel.WorkloadUnit,
                Description = createDailyTaskViewModel.Description,
                CrewCount = createDailyTaskViewModel.CrewCount,
                WorkHours = createDailyTaskViewModel.WorkHours,
                Workload = createDailyTaskViewModel.Workload,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}