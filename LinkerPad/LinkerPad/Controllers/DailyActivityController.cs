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
using LinkerPad.Models.DailyActivity;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Controllers
{
    public class DailyActivityController : ApiController
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IDailyActivityLogic _dailyActivityLogic;
        private readonly IProjectLogic _projectLogic;

        public DailyActivityController(
            ITokenHelper tokenHelper,
            IDailyActivityLogic dailyActivityLogic,
            IProjectLogic projectLogic)
        {
            _tokenHelper = tokenHelper;
            _dailyActivityLogic = dailyActivityLogic;
            _projectLogic = projectLogic;
        }

        [HttpPost]
        [SuperAuthorize]
        public object CreateDailyActivity(CreateDailyActivityViewModel createDailyActivityViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            DailyActivityData dailyActivityData =
                CreateDailyActivityViewModel.GetDailyActivityData(currentUserInfo.Id, createDailyActivityViewModel);

            _dailyActivityLogic.Add(dailyActivityData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectDailyActivityList(Guid projectId, DateTime reportDate)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            IEnumerable<DailyActivityData> dailyActivityDatas = _dailyActivityLogic.GetProjectDailyActivies(projectId, reportDate);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, dailyActivityDatas.Select(DailyActivityViewModel.GetDailyActivityViewModel)));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetDailyActivity(Guid projectId, Guid dailyActivityId)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            DailyActivityData dailyActivityData = _dailyActivityLogic.GetDailyActivity(dailyActivityId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, DailyActivityViewModel.GetDailyActivityViewModel(dailyActivityData)));
        }

        [HttpPost]
        [SuperAuthorize]
        public object EditDailyActivity(EditDailyActivityViewModel editDailyActivityViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_dailyActivityLogic.IsDailyActivityExist(editDailyActivityViewModel.ProjectId, editDailyActivityViewModel.DailyActivityId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, editDailyActivityViewModel.ProjectId) == UserRole.Collaborator
               && !_dailyActivityLogic.IsDailyActivityCreatedBy(currentUserInfo.Id, editDailyActivityViewModel.DailyActivityId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            DailyActivityData dailyActivityData =
                EditDailyActivityViewModel.GetDailyActivityData(editDailyActivityViewModel);

            _dailyActivityLogic.Edit(dailyActivityData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpPost]
        [SuperAuthorize]
        public object DeleteDailyActivity(DeleteDailyActivityViewModel deleteDailyActivityViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_dailyActivityLogic.IsDailyActivityExist(deleteDailyActivityViewModel.ProjectId, deleteDailyActivityViewModel.DailyActivityId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, deleteDailyActivityViewModel.ProjectId) == UserRole.Collaborator
                && !_dailyActivityLogic.IsDailyActivityCreatedBy(currentUserInfo.Id, deleteDailyActivityViewModel.DailyActivityId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            _dailyActivityLogic.Delete(deleteDailyActivityViewModel.DailyActivityId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

    }
}
