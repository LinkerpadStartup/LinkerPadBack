using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    internal class DailyActivityRepository : Repository<DailyActivityData>, IDailyActivityRepository
    {
        public DailyActivityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
