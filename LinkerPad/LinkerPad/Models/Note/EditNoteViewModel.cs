using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Note
{
    public class EditNoteViewModel
    {
        [Required]
        public Guid NoteId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        
        public static NoteData GetNoteData(EditNoteViewModel editNoteViewModel)
        {
            return new NoteData
            {
                Id = editNoteViewModel.NoteId,
                ProjectData = new ProjectData
                {
                    Id = editNoteViewModel.ProjectId
                },
                ReportDate = editNoteViewModel.ReportDate,
                Title = editNoteViewModel.Title,
                Description = editNoteViewModel.Description,
                ModifiedDate = DateTime.Now
            };
        }
    }
}