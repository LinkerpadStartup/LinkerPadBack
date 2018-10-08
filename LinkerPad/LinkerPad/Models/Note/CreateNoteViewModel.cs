using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Note
{
    public class CreateNoteViewModel
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

        
        public static NoteData GetNoteData(Guid userId, CreateNoteViewModel createNoteViewModel)
        {
            return new NoteData
            {
                ProjectData = new ProjectData
                {
                    Id = createNoteViewModel.ProjectId
                },
                CreatedBy = new UserData
                {
                    Id = userId
                },
                ReportDate = createNoteViewModel.ReportDate,
                Title = createNoteViewModel.Title,
                Description = createNoteViewModel.Description,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}