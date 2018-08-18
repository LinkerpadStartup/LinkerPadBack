using System;
using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    class ProjectDataMap : ClassMap<ProjectData>
    {
        public ProjectDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            HasMany(x => x.ProjectTeamDatas)
                .KeyColumn("ProjectId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            References(x => x.UserData).Column("UserId").Not.Nullable();
            Map(x => x.Name).Length(200).Not.Nullable();
            Map(x => x.Code).Length(100).Not.Nullable();
            Map(x => x.Address).Length(500).Not.Nullable();
            Map(x => x.StartDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.EndDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.ModifiedDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.ProjectPicture).Length(40001).Nullable();
            Map(x => x.MaximunmMember).CustomType<int>().Not.Nullable();
            Table("Tbl_Project");
        }
    }
}
