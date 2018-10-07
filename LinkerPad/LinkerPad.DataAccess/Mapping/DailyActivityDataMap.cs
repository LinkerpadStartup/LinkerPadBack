using System;
using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    class DailyActivityDataMap : ClassMap<DailyActivityData>
    {
        public DailyActivityDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.ProjectData).Column("ProjectId").Not.Nullable();
            References(x => x.CreatedBy).Column("UserId").Not.Nullable();
            Map(x => x.Title).Length(500).Not.Nullable();
            Map(x => x.NumberOfCrew).CustomType<int>().Nullable();
            Map(x => x.WorkHours).CustomType<float>().Nullable();
            Map(x => x.Workload).CustomType<float>().Nullable();
            Map(x => x.WorkloadUnit).Length(50).Nullable();
            Map(x => x.ReportDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.ModifiedDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.Description).Length(1000).Nullable();
            Table("Tbl_DailyActivity");
        }
    }
}
