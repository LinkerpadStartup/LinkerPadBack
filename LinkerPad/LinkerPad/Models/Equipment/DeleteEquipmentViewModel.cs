using System;
using System.ComponentModel.DataAnnotations;

namespace LinkerPad.Models.Equipment
{
    public class DeleteEquipmentViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid EquipmentId { get; set; }
    }
}