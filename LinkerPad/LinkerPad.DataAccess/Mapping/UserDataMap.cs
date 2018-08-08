using System;
using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    public class UserDataMap : ClassMap<UserData>
    {
        public UserDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.FirstName).Length(100).Not.Nullable();
            Map(x => x.LastName).Length(100).Not.Nullable();
            Map(x => x.Email).Length(200).Not.Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.MobileNumber).Length(12).Not.Nullable();
            Map(x => x.ProfilePicture).Length(100).Nullable();
            Map(x => x.Company).Length(200).Not.Nullable();
            Map(x => x.Password).Length(40001).Not.Nullable();
            Table("Tbl_User");
        }
    }
}
