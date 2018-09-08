using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    internal class NotesRepository : Repository<NotesData>, INotesRepository
    {
        public NotesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
