﻿using System;
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

        public void Edit(DailyActivityData dailyActivityData)
        {
            _unitOfWork.BeginTransaction();

            DailyActivityData currentDailyActivityData = _dailyActivityRepository.GetById(dailyActivityData.Id);

            currentDailyActivityData.Description = dailyActivityData.Description;
            currentDailyActivityData.NumberOfCrew = dailyActivityData.NumberOfCrew;
            currentDailyActivityData.Title = dailyActivityData.Title;
            currentDailyActivityData.WorkHours = dailyActivityData.WorkHours;
            currentDailyActivityData.Workload = dailyActivityData.Workload;
            currentDailyActivityData.WorkloadUnit = dailyActivityData.WorkloadUnit;
            currentDailyActivityData.ModifiedDate = DateTime.Now;

            _dailyActivityRepository.Update(currentDailyActivityData);

            _unitOfWork.Commit();
        }

        public void Delete(Guid dailyActivityId)
        {
            _unitOfWork.BeginTransaction();

            _dailyActivityRepository.Delete(dailyActivityId);

            _unitOfWork.Commit();
        }

        public DailyActivityData GetDailyActivity(Guid dailyActivityId)
        {
            return _dailyActivityRepository.GetById(dailyActivityId);
        }

        public IEnumerable<DailyActivityData> GetProjectDailyActivies(Guid projectId, DateTime reportDate)
        {
            IQueryable<DailyActivityData> dailyActivitiesDataSource = _dailyActivityRepository.GetAll()
                 .Where(d => d.ProjectData.Id == projectId && d.ReportDate.Date == reportDate.Date);

            return dailyActivitiesDataSource.AsEnumerable();
        }

        public bool IsDailyActivityCreatedBy(Guid currentUserId, Guid dailyActivityId)
        {
            return _dailyActivityRepository.GetById(dailyActivityId).CreatedBy.Id == currentUserId;
        }

        public bool IsDailyActivityExist(Guid projectId, Guid dailyActivityId)
        {
            return _dailyActivityRepository.GetAll().Any(d => d.ProjectData.Id == projectId && d.Id == dailyActivityId);
        }
    }
}
