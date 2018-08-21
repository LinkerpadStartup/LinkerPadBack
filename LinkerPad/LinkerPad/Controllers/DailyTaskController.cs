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
using LinkerPad.Models.DailyTask;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Controllers
{
    public class DailyTaskController : ApiController
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IDailyTaskLogic _dailyTaskLogic;
        private readonly IProjectLogic _projectLogic;

        public DailyTaskController(
            ITokenHelper tokenHelper,
            IDailyTaskLogic dailyTaskLogic,
            IProjectLogic projectLogic)
        {
            _tokenHelper = tokenHelper;
            _dailyTaskLogic = dailyTaskLogic;
            _projectLogic = projectLogic;
        }

        [HttpPost]
        [SuperAuthorize]
        public object CreateDailyTask(CreateDailyTaskViewModel createDailyTaskViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            DailyTaskData dailyTaskData =
                CreateDailyTaskViewModel.GetDailyTaskData(currentUserInfo.Id, createDailyTaskViewModel);

            _dailyTaskLogic.Add(dailyTaskData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectDailyTaskList(Guid projectId, DateTime dailyTaskDate)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            IEnumerable<DailyTaskData> dailyTaskDatas = _dailyTaskLogic.GetProjectDailyTasks(projectId, dailyTaskDate);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, dailyTaskDatas.Select(DailyTaskViewModel.GetDailyTaskViewModel)));
        }
    }
}
