using System;
using LinkerPad.Data;

namespace LinkerPad.Models.Equipment
{
    public class EquipmentViewModel
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime ReportDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int NumberOfActiveEquipment { get; set; }

        public int NumberOfDeactiveEquipment { get; set; }

        public float WorkHours { get; set; }

        public static EquipmentViewModel GetEquipmentViewModel(EquipmentData equipmentData)
        {
            return new EquipmentViewModel
            {
                Id = equipmentData.Id,
                ProjectId = equipmentData.ProjectData.Id,
                CreatedById = equipmentData.CreatedBy.Id,
                ReportDate = equipmentData.ReportDate,
                Title = equipmentData.Title,
                Description = equipmentData.Description,
                NumberOfActiveEquipment = equipmentData.NumberOfActiveEquipment,
                NumberOfDeactiveEquipment = equipmentData.NumberOfDeactiveEquipment,
                WorkHours = equipmentData.WorkHours,
            };
        }
    }
}