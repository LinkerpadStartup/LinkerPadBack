using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Equipment
{
    public class CreateEquipmentViewModel
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
        public int NumberOfActiveEquipment { get; set; }

        [Required]
        public int NumberOfDeactiveEquipment { get; set; }

        [Required]
        public float WorkHours { get; set; }
                
        public static EquipmentData GetEquipmentData(Guid userId, CreateEquipmentViewModel createEquipmentViewModel)
        {
            return new EquipmentData
            {
                ProjectData = new ProjectData
                {
                    Id = createEquipmentViewModel.ProjectId
                },
                CreatedBy = new UserData
                {
                    Id = userId
                },
                ReportDate = createEquipmentViewModel.ReportDate,
                Title = createEquipmentViewModel.Title,
                Description = createEquipmentViewModel.Description,
                NumberOfActiveEquipment = createEquipmentViewModel.NumberOfActiveEquipment,
                NumberOfDeactiveEquipment = createEquipmentViewModel.NumberOfDeactiveEquipment,
                WorkHours = createEquipmentViewModel.WorkHours,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}