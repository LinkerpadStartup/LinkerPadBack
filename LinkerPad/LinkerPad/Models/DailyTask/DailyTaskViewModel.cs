using System;
using LinkerPad.Data;

namespace LinkerPad.Models.DailyTask
{
    public class DailyTaskViewModel
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime DailyTaskDate { get; set; }

        public string Title { get; set; }

        public string WorkloadUnit { get; set; }

        public string Description { get; set; }

        public int CrewCount { get; set; }

        public int WorkHours { get; set; }

        public int Workload { get; set; }

        public static DailyTaskViewModel GetDailyTaskViewModel(DailyTaskData dailyTaskData)
        {
            return new DailyTaskViewModel
            {
                Id = dailyTaskData.Id,
                ProjectId = dailyTaskData.ProjectData.Id,
                CreatedById = dailyTaskData.CreatedBy.Id,
                DailyTaskDate = dailyTaskData.DailyTaskDate,
                Title = dailyTaskData.Title,
                WorkloadUnit = dailyTaskData.WorkloadUnit,
                Description = dailyTaskData.Description,
                CrewCount = dailyTaskData.CrewCount,
                WorkHours = dailyTaskData.WorkHours,
                Workload = dailyTaskData.Workload
            };
        }
    }
}