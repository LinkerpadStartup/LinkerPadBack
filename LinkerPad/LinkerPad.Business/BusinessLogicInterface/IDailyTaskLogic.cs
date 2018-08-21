using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IDailyTaskLogic
    {
        void Add(DailyTaskData dailyTaskData);

        IEnumerable<DailyTaskData> GetProjectDailyTasks(Guid projectId, DateTime dailyTaskDate);
    }
}