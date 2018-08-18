using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    class UserProductDataMap : ClassMap<ProductTeamData>
    {
        public UserProductDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x=>x.UserData).Column("UserId").Not.Nullable();
            References(x=>x.ProjectData).Column("ProjectId").Not.Nullable();
            Map(x => x.UserRole).CustomType<int>().Not.Nullable();
            Table("Tbl_ProjectTeam");
        }
    }
}
