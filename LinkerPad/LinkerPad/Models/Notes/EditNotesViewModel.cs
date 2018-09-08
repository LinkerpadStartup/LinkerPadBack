using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Notes
{
    public class EditNotesViewModel
    {
        [Required]
        public Guid NotesId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        
        public static NotesData GetNotesData(EditNotesViewModel editNotesViewModel)
        {
            return new NotesData
            {
                Id = editNotesViewModel.NotesId,
                ProjectData = new ProjectData
                {
                    Id = editNotesViewModel.ProjectId
                },
                ReportDate = editNotesViewModel.ReportDate,
                Title = editNotesViewModel.Title,
                Description = editNotesViewModel.Description,
                ModifiedDate = DateTime.Now
            };
        }
    }
}