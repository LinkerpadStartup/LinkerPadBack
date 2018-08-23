using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IDailyActivityLogic
    {
        void Add(DailyActivityData dailyActivityData);

        void Edit(DailyActivityData dailyActivityData);

        void Delete(Guid dailyActivityId);

        IEnumerable<DailyActivityData> GetProjectDailyActivies(Guid projectId, DateTime reportDate);

        bool IsDailyActivityCreatedBy(Guid currentUserId,Guid dailyActivityId);

        bool IsDailyActivityExist(Guid projectId, Guid dailyActivityId);
    }
}