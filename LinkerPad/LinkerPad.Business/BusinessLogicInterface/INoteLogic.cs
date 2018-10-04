using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface INoteLogic
    {
        void Add(NoteData noteData);

        void Edit(NoteData noteData);

        void Delete(Guid noteId);

        NoteData GetNote(Guid noteId);

        IEnumerable<NoteData> GetProjectNote(Guid projectId, DateTime reportDate);

        bool IsNoteCreatedBy(Guid currentUserId, Guid noteId);

        bool IsNoteExist(Guid projectId, Guid noteId);
    }
}