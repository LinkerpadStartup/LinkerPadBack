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
    }
}
