using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Notes
{
    public class CreateNotesViewModel
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

        
        public static NotesData GetNotesData(Guid userId, CreateNotesViewModel createNotesViewModel)
        {
            return new NotesData
            {
                ProjectData = new ProjectData
                {
                    Id = createNotesViewModel.ProjectId
                },
                CreatedBy = new UserData
                {
                    Id = userId
                },
                ReportDate = createNotesViewModel.ReportDate,
                Title = createNotesViewModel.Title,
                Description = createNotesViewModel.Description,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}