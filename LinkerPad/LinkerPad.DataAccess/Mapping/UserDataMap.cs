﻿using System;
using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    class UserDataMap : ClassMap<UserData>
    {
        public UserDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            HasMany(x => x.Projects)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.ProjectTeamDatas)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.DailyActivityDatas)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.ConfirmationDatas)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.MaterialDatas)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.EquipmentDatas)
               .KeyColumn("UserId")
               .Inverse()
               .Cascade.AllDeleteOrphan();
            HasMany(x => x.NoteDatas)
               .KeyColumn("UserId")
               .Inverse()
               .Cascade.AllDeleteOrphan();
            Map(x => x.FirstName).Length(100).Not.Nullable();
            Map(x => x.LastName).Length(100).Not.Nullable();
            Map(x => x.Email).Length(200).Not.Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.ModifiedDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.MobileNumber).Length(12).Not.Nullable();
            Map(x => x.ProfilePicture).Length(40001).Nullable();
            Map(x => x.Company).Length(200).Nullable();
            Map(x => x.Skill).Length(200).Nullable();
            Map(x => x.Password).Length(40001).Not.Nullable();
            Table("Tbl_User");
        }
    }
}
