using System;
using LinkerPad.Data;

namespace LinkerPad.Models.Material
{
    public class MaterialViewModel
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime ReportDate { get; set; }

        public string Title { get; set; }

        public string ConsumedQuantityUnit { get; set; }

        public string Description { get; set; }

        public float ConsumedQuantity { get; set; }

        public static MaterialViewModel GetMaterialViewModel(MaterialData materialData)
        {
            return new MaterialViewModel
            {
                Id = materialData.Id,
                ProjectId = materialData.ProjectData.Id,
                CreatedById = materialData.CreatedBy.Id,
                ReportDate = materialData.ReportDate,
                Title = materialData.Title,
                ConsumedQuantityUnit = materialData.ConsumedQuantityUnit,
                Description = materialData.Description,
                ConsumedQuantity = materialData.ConsumedQuantity,
            };
        }
    }
}