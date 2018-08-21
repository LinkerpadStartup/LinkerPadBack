using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class DailyTaskLogic : IDailyTaskLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDailyTaskRepository _dailyTaskRepository;

        public DailyTaskLogic(IUnitOfWork unitOfWork, IDailyTaskRepository dailyTaskRepository)
        {
            _unitOfWork = unitOfWork;
            _dailyTaskRepository = dailyTaskRepository;
        }

        public void Add(DailyTaskData dailyTaskData)
        {
            _unitOfWork.BeginTransaction();

            _dailyTaskRepository.Create(dailyTaskData);

            _unitOfWork.Commit();
        }
    }
}
