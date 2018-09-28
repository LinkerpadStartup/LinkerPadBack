using System;
using LinkerPad.Data;

namespace LinkerPad.Models.Notes
{
    public class NotesViewModel
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime ReportDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public static NotesViewModel GetNotesViewModel(NotesData NotesData)
        {
            return new NotesViewModel
            {
                Id = NotesData.Id,
                ProjectId = NotesData.ProjectData.Id,
                CreatedById = NotesData.CreatedBy.Id,
                ReportDate = NotesData.ReportDate,
                Title = NotesData.Title,
                Description = NotesData.Description,
            };
        }
    }
}