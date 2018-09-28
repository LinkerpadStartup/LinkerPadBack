using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    internal class NoteRepository : Repository<NoteData>, INoteRepository
    {
        public NoteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
