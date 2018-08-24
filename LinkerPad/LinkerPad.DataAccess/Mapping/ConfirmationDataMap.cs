using System;
using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    class ConfirmationDataMap : ClassMap<ConfirmationData>
    {
        public ConfirmationDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.ConfirmedBy).Column("UserId").Not.Nullable();
            References(x => x.ProjectData).Column("ProjectId").Not.Nullable();
            Map(x => x.ReportDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Table("Tbl_Confirmation");
        }
    }
}
