using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Material
{
    public class CreateMaterialViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
               
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string ConsumedQuantityUnit { get; set; }

        [Required]
        public float ConsumedQuantity { get; set; }

        public static MaterialData GetMaterialData(Guid userId, CreateMaterialViewModel createMaterialViewModel)
        {
            return new MaterialData
            {
                ProjectData = new ProjectData
                {
                    Id = createMaterialViewModel.ProjectId
                },
                CreatedBy = new UserData
                {
                    Id = userId
                },
                ReportDate = createMaterialViewModel.ReportDate,
                Title = createMaterialViewModel.Title,
                ConsumedQuantityUnit = createMaterialViewModel.ConsumedQuantityUnit,
                Description = createMaterialViewModel.Description,
                ConsumedQuantity = createMaterialViewModel.ConsumedQuantity,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}