using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IDailyActivityLogic
    {
        void Add(DailyActivityData dailyActivityData);

        IEnumerable<DailyActivityData> GetProjectDailyActivies(Guid projectId, DateTime reportDate);
    }
}