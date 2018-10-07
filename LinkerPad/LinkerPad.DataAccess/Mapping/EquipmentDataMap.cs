using System;
using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    class EquipmentDataMap : ClassMap<EquipmentData>
    {
        public EquipmentDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.ProjectData).Column("ProjectId").Not.Nullable();
            References(x => x.CreatedBy).Column("UserId").Not.Nullable();
            Map(x => x.Title).Length(500).Not.Nullable();
            Map(x => x.WorkHours).CustomType<float>().Nullable();
            Map(x => x.NumberOfActiveEquipment).CustomType<int>().Nullable();
            Map(x => x.NumberOfDeactiveEquipment).CustomType<int>().Nullable();
            Map(x => x.ReportDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.ModifiedDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.Description).Length(1000).Nullable();
            Table("Tbl_Equipment");
        }
    }
}
