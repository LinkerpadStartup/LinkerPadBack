using System;
using System.ComponentModel.DataAnnotations;

namespace LinkerPad.Models.Note
{
    public class DeleteNoteViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid NoteId { get; set; }
    }
}