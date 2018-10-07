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

        public static NoteViewModel GetNoteViewModel(NoteData noteData)
        {
            return new NoteViewModel
            {
                Id = noteData.Id,
                ProjectId = noteData.ProjectData.Id,
                CreatedById = noteData.CreatedBy.Id,
                ReportDate = noteData.ReportDate,
                Title = noteData.Title,
                Description = noteData.Description,
            };
        }
    }
}