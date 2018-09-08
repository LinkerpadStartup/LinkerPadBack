using System;
using System.ComponentModel.DataAnnotations;

namespace LinkerPad.Models.Notes
{
    public class DeleteNotesViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid NotesId { get; set; }
    }
}