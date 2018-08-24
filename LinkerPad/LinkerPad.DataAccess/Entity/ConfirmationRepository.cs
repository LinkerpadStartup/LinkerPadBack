using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    internal class ConfirmationRepository : Repository<ConfirmationData>, IConfirmationRepository
    {
        public ConfirmationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
