using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Material
{
    public class EditMaterialViewModel
    {
        [Required]
        public Guid MaterialId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string ConsumedQuantityUnit { get; set; }

        public float ConsumedQuantity { get; set; }

        public static MaterialData GetMaterialData(EditMaterialViewModel editMaterialViewModel)
        {
            return new MaterialData
            {
                Id = editMaterialViewModel.MaterialId,
                ProjectData = new ProjectData
                {
                    Id = editMaterialViewModel.ProjectId
                },
                ReportDate = editMaterialViewModel.ReportDate,
                Title = editMaterialViewModel.Title,
                Description = editMaterialViewModel.Description,
                ConsumedQuantity = editMaterialViewModel.ConsumedQuantity,
                ConsumedQuantityUnit = editMaterialViewModel.ConsumedQuantityUnit,
                ModifiedDate = DateTime.Now
            };
        }
    }
}