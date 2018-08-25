using System;
using System.ComponentModel.DataAnnotations;

namespace LinkerPad.Models.Material
{
    public class DeleteMaterialViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid MaterialId { get; set; }
    }
}