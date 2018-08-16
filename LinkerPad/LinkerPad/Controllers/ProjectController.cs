using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Common;
using LinkerPad.Common.CustomeAuthorizeAttribute;
using LinkerPad.Data;
using LinkerPad.Models.Project;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

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
    }
}
