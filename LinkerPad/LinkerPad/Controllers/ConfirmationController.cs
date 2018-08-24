using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Common;
using LinkerPad.Common.CustomeAuthorizeAttribute;
using LinkerPad.Data;
using LinkerPad.Models.Account;
using LinkerPad.Models.Confirmation;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Controllers
{
    public class ConfirmationController : ApiController
    {
        private readonly IConfirmationLogic _confirmationLogic;
        private readonly ITokenHelper _tokenHelper;
        private readonly IProjectLogic _projectLogic;

        public ConfirmationController(IConfirmationLogic confirmationLogic, ITokenHelper tokenHelper, IProjectLogic projectLogic)
        {
            _tokenHelper = tokenHelper;
            _confirmationLogic = confirmationLogic;
            _projectLogic = projectLogic;
        }

        [HttpPost]
        [SuperAuthorize]
        public object CreateConfirmation(CreateConfirmationViewModel createConfirmationViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, createConfirmationViewModel.ProjectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            //TODO: check if in this day there is any report!!!!

            if (_confirmationLogic.IsReportConfirmedBy(createConfirmationViewModel.ProjectId, currentUserInfo.Id, createConfirmationViewModel.ReportDate))
                return Request.CreateResponse(HttpStatusCode.Conflict, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.AlreadyConfirmedThisReport));

            ConfirmationData confirmationData =
                CreateConfirmationViewModel.GetConfirmationData(currentUserInfo.Id, createConfirmationViewModel);

            _confirmationLogic.Add(confirmationData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(), ResponseMessagesModel.Success));
        }

        [HttpPost]
        [SuperAuthorize]
        public object DeleteConfirmation(DeleteConfirmationViewModel deleteConfirmationViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, deleteConfirmationViewModel.ProjectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            //TODO: check if in this day there is any report!!!!

            if (!_confirmationLogic.IsReportConfirmedBy(deleteConfirmationViewModel.ProjectId, currentUserInfo.Id, deleteConfirmationViewModel.ReportDate))
                return Request.CreateResponse(HttpStatusCode.Conflict, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.ConfirmationNotFound));

            ConfirmationData confirmationData =
                DeleteConfirmationViewModel.GetConfirmationData(currentUserInfo.Id, deleteConfirmationViewModel);

            _confirmationLogic.Delete(confirmationData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(), ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectConfirmationList(Guid projectId, DateTime reportDate)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            ProjectData projectData = _projectLogic.GetProjectData(projectId);

            IList<ReportConfirmationViewModel> reportConfirmationViewModels = projectData.ProjectTeamDatas.Select(pt =>
                ReportConfirmationViewModel.GetReportConfirmationViewModel(
                    pt.UserData, projectData, reportDate)).ToList();

            reportConfirmationViewModels.Add(ReportConfirmationViewModel.GetReportConfirmationViewModel(projectData.UserData, projectData, reportDate));

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, reportConfirmationViewModels));
        }
    }
}
