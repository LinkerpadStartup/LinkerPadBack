using System;
using FluentNHibernate.Mapping;
using LinkerPad.Data;

namespace LinkerPad.DataAccess.Mapping
{
    class NotesDataMap : ClassMap<NotesData>
    {
        public NotesDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            References(x => x.ProjectData).Column("ProjectId").Not.Nullable();
            References(x => x.CreatedBy).Column("UserId").Not.Nullable();
            Map(x => x.Title).Length(200).Not.Nullable();
            Map(x => x.ReportDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.ModifiedDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.Description).Length(500).Nullable();
            Table("Tbl_Notes");
        }
    }
}
