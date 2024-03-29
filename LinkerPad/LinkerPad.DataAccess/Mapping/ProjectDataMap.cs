﻿using System;
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
            HasMany(x => x.DailyActivityDatas)
                .KeyColumn("ProjectId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.ConfirmationDatas)
                .KeyColumn("ProjectId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.EquipmentDatas)
                .KeyColumn("ProjectId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.MaterialDatas)
               .KeyColumn("ProjectId")
               .Inverse()
               .Cascade.AllDeleteOrphan();
            HasMany(x => x.NoteDatas)
               .KeyColumn("ProjectId")
               .Inverse()
               .Cascade.AllDeleteOrphan();
            References(x => x.UserData).Column("UserId").Not.Nullable();
            Map(x => x.Name).Length(200).Not.Nullable();
            Map(x => x.Code).Length(100).Nullable();
            Map(x => x.Address).Length(500).Not.Nullable();
            Map(x => x.StartDate).CustomType<DateTime>().Nullable();
            Map(x => x.EndDate).CustomType<DateTime>().Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.ModifiedDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.ProjectPicture).Length(40001).Nullable();
            Map(x => x.MaximunmMember).CustomType<int>().Not.Nullable();
            Table("Tbl_Project");
        }
    }
}
