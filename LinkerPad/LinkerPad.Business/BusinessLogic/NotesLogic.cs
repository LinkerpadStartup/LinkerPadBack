using System;
using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class NotesLogic : INotesLogic
    {
                private readonly INotesRepository _NotesRepository;

        public void Add(NotesData NotesData)
        {
            _NotesRepository.Create(NotesData);
        }

        public void Edit(NotesData NotesData)
        {
            NotesData currentNotesData = _NotesRepository.GetById(NotesData.Id);

            currentNotesData.Description = NotesData.Description;
            currentNotesData.Title = NotesData.Title;
            currentNotesData.ModifiedDate = DateTime.Now;

            _NotesRepository.Update(currentNotesData);

        }

        public void Delete(Guid NotesId)
        {

            _NotesRepository.Delete(NotesId);

        }

        public NotesData GetNotes(Guid NotesId)
        {
            return _NotesRepository.GetById(NotesId);
        }

        public IEnumerable<NotesData> GetProjectNotes(Guid projectId, DateTime reportDate)
        {
            IQueryable<NotesData> NotessDataSource = _NotesRepository.GetAll()
                 .Where(d => d.ProjectData.Id == projectId && d.ReportDate.Date == reportDate.Date);

            return NotessDataSource.AsEnumerable();
        }

        public bool IsNotesCreatedBy(Guid currentUserId, Guid NotesId)
        {
            return _NotesRepository.GetById(NotesId).CreatedBy.Id == currentUserId;
        }

        public bool IsNotesExist(Guid projectId, Guid NotesId)
        {
            return _NotesRepository.GetAll().Any(d => d.ProjectData.Id == projectId && d.Id == NotesId);
        }
    }
}
