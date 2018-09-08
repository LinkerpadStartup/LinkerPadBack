using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface INotesLogic
    {
        void Add(NotesData NotesData);

        void Edit(NotesData NotesData);

        void Delete(Guid NotesId);

        NotesData GetNotes(Guid NotesId);

        IEnumerable<NotesData> GetProjectNotes(Guid projectId, DateTime reportDate);

        bool IsNotesCreatedBy(Guid currentUserId, Guid NotesId);

        bool IsNotesExist(Guid projectId, Guid NotesId);
    }
}