using System;

namespace LinkerPad.Data
{
    public class DailyTaskData
    {
        public virtual Guid Id { set; get; }

        public virtual ProjectData ProjectData { set; get; }

        public virtual UserData CreatedBy { set; get; }

        public virtual DateTime DailyTaskDate { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }

        public virtual string Title { get; set; }

        public virtual string WorkloadUnit { get; set; }

        public virtual string Description { get; set; }

        public virtual int CrewCount { get; set; }

        public virtual int WorkHours { get; set; }

        public virtual int Workload { get; set; }
    }
}
