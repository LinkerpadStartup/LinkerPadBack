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
            Map(x => x.Name).Length(100).Not.Nullable();
            Map(x => x.Code).Length(100).Not.Nullable();
            Map(x => x.Address).Length(200).Not.Nullable();
            Map(x => x.StartDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.EndDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.CreateDate).CustomType<DateTime>().Not.Nullable();
            Map(x => x.ProjectPicture).Length(40001).Nullable();
            Map(x => x.MaximunmMember).CustomType<int>().Not.Nullable();
            Table("Tbl_Project");
        }
    }
}