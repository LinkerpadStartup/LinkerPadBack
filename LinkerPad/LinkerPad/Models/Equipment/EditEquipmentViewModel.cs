﻿using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Equipment
{
    public class EditEquipmentViewModel
    {
        [Required]
        public Guid EquipmentId { get; set; }

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
      
        public static EquipmentData GetEquipmentData(EditEquipmentViewModel editEquipmentViewModel)
        {
            return new EquipmentData
            {
                Id = editEquipmentViewModel.EquipmentId,
                ProjectData = new ProjectData
                {
                    Id = editEquipmentViewModel.ProjectId
                },
                ReportDate = editEquipmentViewModel.ReportDate,
                Title = editEquipmentViewModel.Title,
                Description = editEquipmentViewModel.Description,
                NumberOfActiveEquipment = editEquipmentViewModel.NumberOfActiveEquipment,
                NumberOfDeactiveEquipment = editEquipmentViewModel.NumberOfDeactiveEquipment,
                WorkHours = editEquipmentViewModel.WorkHours,
                ModifiedDate = DateTime.Now
            };
        }
    }
}