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

        public void Add(NoteData NoteData)
        {
            _noteRepository.Create(NoteData);
        }

        public void Edit(NoteData NoteData)
        {
            NoteData currentNoteData = _noteRepository.GetById(NoteData.Id);

            currentNoteData.Description = NoteData.Description;
            currentNoteData.Title = NoteData.Title;
            currentNoteData.ModifiedDate = DateTime.Now;

            _noteRepository.Update(currentNoteData);

        }

        public void Delete(Guid NoteId)
        {

            _noteRepository.Delete(NoteId);

        }

        public NoteData GetNote(Guid NoteId)
        {
            return _noteRepository.GetById(NoteId);
        }

        public IEnumerable<NoteData> GetProjectNote(Guid projectId, DateTime reportDate)
        {
            IQueryable<NoteData> NoteDataSource = _noteRepository.GetAll()
                 .Where(d => d.ProjectData.Id == projectId && d.ReportDate.Date == reportDate.Date);

            return NoteDataSource.AsEnumerable();
        }

        public bool IsNoteCreatedBy(Guid currentUserId, Guid NoteId)
        {
            return _noteRepository.GetById(NoteId).CreatedBy.Id == currentUserId;
        }

        public bool IsNoteExist(Guid projectId, Guid NoteId)
        {
            return _noteRepository.GetAll().Any(d => d.ProjectData.Id == projectId && d.Id == NoteId);
        }
    }
}
