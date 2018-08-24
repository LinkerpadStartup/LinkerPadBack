using System;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IConfirmationLogic
    {
        void Add(ConfirmationData confirmationData);

        void Delete(ConfirmationData confirmationData);

        bool IsReportConfirmedBy(Guid projectId, Guid userId, DateTime reportDate);
    }
}