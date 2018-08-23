using System;
using LinkerPad.Data;

namespace LinkerPad.Models.DailyActivity
{
    public class DailyActivityViewModel
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime ReportDate { get; set; }

        public string Title { get; set; }

        public string WorkloadUnit { get; set; }

        public string Description { get; set; }

        public int NumberOfCrew { get; set; }

        public float WorkHours { get; set; }

        public float Workload { get; set; }

        public static DailyActivityViewModel GetDailyActivityViewModel(DailyActivityData dailyActivityData)
        {
            return new DailyActivityViewModel
            {
                Id = dailyActivityData.Id,
                ProjectId = dailyActivityData.ProjectData.Id,
                CreatedById = dailyActivityData.CreatedBy.Id,
                ReportDate = dailyActivityData.ReportDate,
                Title = dailyActivityData.Title,
                WorkloadUnit = dailyActivityData.WorkloadUnit,
                Description = dailyActivityData.Description,
                NumberOfCrew = dailyActivityData.NumberOfCrew,
                WorkHours = dailyActivityData.WorkHours,
                Workload = dailyActivityData.Workload
            };
        }
    }
}