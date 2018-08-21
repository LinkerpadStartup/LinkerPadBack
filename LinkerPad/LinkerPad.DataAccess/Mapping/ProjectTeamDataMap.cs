using System;
using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    class ProjectTeamDataMap : ClassMap<ProjectTeamData>
    {
        public ProjectTeamDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.UserData).Column("UserId").Not.Nullable();
            References(x => x.ProjectData).Column("ProjectId").Not.Nullable();
            Map(x => x.UserRole).CustomType<int>().Not.Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Table("Tbl_ProjectTeam");
        }
    }
}
