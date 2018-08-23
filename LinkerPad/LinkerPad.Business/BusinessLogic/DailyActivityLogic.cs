using System;
using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class DailyActivityLogic : IDailyActivityLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDailyActivityRepository _dailyActivityRepository;

        public DailyActivityLogic(IUnitOfWork unitOfWork, IDailyActivityRepository dailyActivityRepository)
        {
            _unitOfWork = unitOfWork;
            _dailyActivityRepository = dailyActivityRepository;
        }

        public void Add(DailyActivityData dailyActivityData)
        {
            _unitOfWork.BeginTransaction();

            _dailyActivityRepository.Create(dailyActivityData);

            _unitOfWork.Commit();
        }

        public IEnumerable<DailyActivityData> GetProjectDailyActivies(Guid projectId, DateTime reportDate)
        {
            _unitOfWork.BeginTransaction();

            IQueryable<DailyActivityData> dailyActivitiesDataSource = _dailyActivityRepository.GetAll()
                 .Where(d => d.ProjectData.Id == projectId && d.ReportDate.Date == reportDate.Date);

            return dailyActivitiesDataSource.AsEnumerable();
        }
    }
}
