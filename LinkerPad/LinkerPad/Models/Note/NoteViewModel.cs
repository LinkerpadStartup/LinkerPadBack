using System;
using LinkerPad.Data;

namespace LinkerPad.Models.Note
{
    public class NoteViewModel
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime ReportDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public static NoteViewModel GetNoteViewModel(NoteData NoteData)
        {
            return new NoteViewModel
            {
                Id = NoteData.Id,
                ProjectId = NoteData.ProjectData.Id,
                CreatedById = NoteData.CreatedBy.Id,
                ReportDate = NoteData.ReportDate,
                Title = NoteData.Title,
                Description = NoteData.Description,
            };
        }
    }
}