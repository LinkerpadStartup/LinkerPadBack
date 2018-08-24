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
using LinkerPad.Models.ProjectTeam;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Controllers
{
    public class ProjectTeamController : ApiController
    {
        private readonly IProjectLogic _projectLogic;
        private readonly ITokenHelper _tokenHelper;
        private readonly IAccountLogic _accountLogic;
        private readonly IProjectTeamLogic _projectTeamLogic;

        public ProjectTeamController(
            IProjectLogic projectLogic,
            ITokenHelper tokenHelper,
            IAccountLogic accountLogic,
            IProjectTeamLogic projectTeamLogic)
        {
            _projectLogic = projectLogic;
            _tokenHelper = tokenHelper;
            _accountLogic = accountLogic;
            _projectTeamLogic = projectTeamLogic;
        }

        [HttpPost]
        [SuperAuthorize]
        public object AddMemberToProject(CreateProjectTeamViewModel createProjectTeamViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, createProjectTeamViewModel.ProjectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            if (!_projectLogic.IsUserAdminOrCreatorOfProject(currentUserInfo.Id, createProjectTeamViewModel.ProjectId) || createProjectTeamViewModel.UserRole == UserRole.Creator)
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            if (!_accountLogic.IsUserExist(createProjectTeamViewModel.EmailAddress.ToLower()))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.UserIsNotFound));

            if (_projectTeamLogic.IsUserExistInProject(createProjectTeamViewModel.EmailAddress.ToLower(), createProjectTeamViewModel.ProjectId))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.UserAlreadyExistInProject));

            ProjectTeamData projectTeamData = CreateProjectTeamViewModel.GetProjectTeamData(
                _accountLogic.GetUser(createProjectTeamViewModel.EmailAddress).Id, createProjectTeamViewModel);

            _projectTeamLogic.Add(projectTeamData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectMemberList(Guid projectId)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            ProjectData projectData = _projectLogic.GetProjectData(projectId);

            IList<UserInformationViewModel> userInformationsViewModel = projectData.ProjectTeamDatas.Select(pt =>
                UserInformationViewModel.GetUserInformationViewModel(
                    pt.UserData, projectData)).ToList();
            userInformationsViewModel.Add(UserInformationViewModel.GetUserInformationViewModel(projectData.UserData, projectData));

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, userInformationsViewModel));
        }

        [HttpPost]
        [SuperAuthorize]
        public object RemoveMemberFromProject(RemoveMemberViewModel removeMemberViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, removeMemberViewModel.ProjectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            if (!_projectLogic.IsUserAdminOrCreatorOfProject(currentUserInfo.Id, removeMemberViewModel.ProjectId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            if (!_accountLogic.IsUserExist(removeMemberViewModel.UserId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.UserIsNotFound));

            if (_projectTeamLogic.IsUserExistInProject(removeMemberViewModel.UserId, removeMemberViewModel.ProjectId))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.UserAlreadyExistInProject));

            ProjectTeamData projectTeamData = RemoveMemberViewModel.GetProjectTeamData(removeMemberViewModel);

            _projectTeamLogic.Delete(projectTeamData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        public object ChangeUserRoleInProject(ChangeUserRoleViewModel changeUserRoleViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, changeUserRoleViewModel.ProjectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            if (!_projectLogic.IsUserAdminOrCreatorOfProject(currentUserInfo.Id, changeUserRoleViewModel.ProjectId) || changeUserRoleViewModel.UserRole == UserRole.Creator)
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            if (!_accountLogic.IsUserExist(changeUserRoleViewModel.UserId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.UserIsNotFound));

            if (_projectTeamLogic.IsUserExistInProject(changeUserRoleViewModel.UserId, changeUserRoleViewModel.ProjectId))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.UserAlreadyExistInProject));

            ProjectTeamData projectTeamData = ChangeUserRoleViewModel.GetProjectTeamData(changeUserRoleViewModel);

            _projectTeamLogic.ChangeUserRole(projectTeamData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }
    }
}
