using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    internal class DailyTaskRepository : Repository<DailyTaskData>, IDailyTaskRepository
    {
        public DailyTaskRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
