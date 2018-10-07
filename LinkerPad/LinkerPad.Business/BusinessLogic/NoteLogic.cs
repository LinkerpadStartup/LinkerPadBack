using System;
using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class NoteLogic : INoteLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INoteRepository _noteRepository;

        public NoteLogic(IUnitOfWork unitOfWork, INoteRepository noteRepository)
        {
            _unitOfWork = unitOfWork;
            _noteRepository = noteRepository;
        }
        public void Add(NoteData noteData)
        {
            _unitOfWork.BeginTransaction();

            _noteRepository.Create(noteData);

            _unitOfWork.Commit();
        }

        public void Edit(NoteData noteData)
        {
            _unitOfWork.BeginTransaction();

            NoteData currentNoteData = _noteRepository.GetById(noteData.Id);

            currentNoteData.Description = noteData.Description;
            currentNoteData.Title = noteData.Title;
            currentNoteData.ModifiedDate = DateTime.Now;

            _noteRepository.Update(currentNoteData);

            _unitOfWork.Commit();
        }

        public void Delete(Guid noteId)
        {
            _unitOfWork.BeginTransaction();

            _noteRepository.Delete(noteId);

            _unitOfWork.Commit();
        }

        public NoteData GetNote(Guid noteId)
        {
            return _noteRepository.GetById(noteId);
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
