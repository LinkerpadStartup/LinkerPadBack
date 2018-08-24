using System;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class ConfirmationLogic : IConfirmationLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfirmationRepository _confirmationRepository;

        public ConfirmationLogic(IUnitOfWork unitOfWork, IConfirmationRepository confirmationRepository)
        {
            _unitOfWork = unitOfWork;
            _confirmationRepository = confirmationRepository;
        }

        public void Add(ConfirmationData confirmationData)
        {
            _unitOfWork.BeginTransaction();

            _confirmationRepository.Create(confirmationData);

            _unitOfWork.Commit();
        }

        public void Delete(ConfirmationData confirmationData)
        {
            ConfirmationData currentconfirmationData = _confirmationRepository.GetAll()
                .First(c => c.ProjectData.Id == confirmationData.ProjectData.Id
                            && c.ConfirmedBy.Id == confirmationData.ConfirmedBy.Id
                            && c.ReportDate.Date == confirmationData.ReportDate.Date);

            _confirmationRepository.Delete(currentconfirmationData.Id);
        }

        public bool IsReportConfirmedBy(Guid projectId, Guid userId, DateTime reportDate)
        {
            return _confirmationRepository.GetAll()
                .Any(c => c.ProjectData.Id == projectId
                            && c.ConfirmedBy.Id == userId
                            && c.ReportDate.Date == reportDate.Date);
        }
    }
}
