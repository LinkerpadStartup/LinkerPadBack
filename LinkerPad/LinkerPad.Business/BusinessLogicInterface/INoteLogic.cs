using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface INoteLogic
    {
        void Add(NoteData NoteData);

        void Edit(NoteData NoteData);

        void Delete(Guid NoteId);

        NoteData GetNote(Guid NoteId);

        IEnumerable<NoteData> GetProjectNote(Guid projectId, DateTime reportDate);

        bool IsNoteCreatedBy(Guid currentUserId, Guid NoteId);

        bool IsNoteExist(Guid projectId, Guid NoteId);
    }
}