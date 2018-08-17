using System;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Common;
using LinkerPad.Common.CustomeAuthorizeAttribute;
using LinkerPad.Data;
using LinkerPad.Models.Project;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LinkerPad.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly IProjectLogic _projectLogic;
        private readonly ITokenHelper _tokenHelper;

        public ProjectController(IProjectLogic projectLogic, ITokenHelper tokenHelper)
        {
            _projectLogic = projectLogic;
            _tokenHelper = tokenHelper;
        }

        [HttpPost]
        [SuperAuthorize]
        public object CreateProject(CreateProjectViewModel createProjectViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            ProjectData projectData = CreateProjectViewModel.GetProjectData(currentUserInfo.Id, createProjectViewModel);

            _projectLogic.Add(projectData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(), ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectList()
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            IEnumerable<ProjectData> projectDatas = _projectLogic.GetUserProjects(currentUserInfo.Id);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, projectDatas.Select(ProjectViewModel.GetProjectViewModel)));
        }

        [HttpPost]
        [SuperAuthorize]
        public object EditProject(EditProjectViewModel editProjectViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsUserProjectOwner(currentUserInfo.Id, editProjectViewModel.Id))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            ProjectData projectData = EditProjectViewModel.GetProjectData(editProjectViewModel);

            _projectLogic.Edit(projectData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectInformation(Guid projectId)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            ProjectData projectData = _projectLogic.GetProjectData(projectId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, ProjectViewModel.GetProjectViewModel(projectData)));
        }
    }
}
