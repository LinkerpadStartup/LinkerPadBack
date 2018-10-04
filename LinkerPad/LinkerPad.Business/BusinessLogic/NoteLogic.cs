using System;
using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;

namespace LinkerPad.Business.BusinessLogic
{
    internal class NoteLogic : INoteLogic
    {
        private readonly INoteRepository _noteRepository;

        public NoteLogic(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public void Add(NoteData noteData)
        {
            _noteRepository.Create(noteData);
        }

        public void Edit(NoteData noteData)
        {
            NoteData currentNoteData = _noteRepository.GetById(noteData.Id);

            currentNoteData.Description = noteData.Description;
            currentNoteData.Title = noteData.Title;
            currentNoteData.ModifiedDate = DateTime.Now;

            _noteRepository.Update(currentNoteData);

        }

        public void Delete(Guid noteId)
        {

            _noteRepository.Delete(noteId);

        }

        public NoteData GetNote(Guid NoteId)
        {
            return _noteRepository.GetById(NoteId);
        }

        public IEnumerable<NoteData> GetProjectNote(Guid projectId, DateTime reportDate)
        {
            IQueryable<NoteData> noteDataSource = _noteRepository.GetAll()
                 .Where(d => d.ProjectData.Id == projectId && d.ReportDate.Date == reportDate.Date);

            return noteDataSource.AsEnumerable();
        }

        public bool IsNoteCreatedBy(Guid currentUserId, Guid noteId)
        {
            return _noteRepository.GetById(noteId).CreatedBy.Id == currentUserId;
        }

        public bool IsNoteExist(Guid projectId, Guid noteId)
        {
            return _noteRepository.GetAll().Any(d => d.ProjectData.Id == projectId && d.Id == noteId);
        }
    }
}
