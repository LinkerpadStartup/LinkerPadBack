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
using LinkerPad.Models.Equipment;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Controllers
{
    public class EquipmentController : ApiController
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IEquipmentLogic _equipmentLogic;
        private readonly IProjectLogic _projectLogic;

        public EquipmentController(
            ITokenHelper tokenHelper,
            IEquipmentLogic equipmentLogic,
            IProjectLogic projectLogic)
        {
            _tokenHelper = tokenHelper;
            _equipmentLogic = equipmentLogic;
            _projectLogic = projectLogic;
        }
        [HttpPost]
        [SuperAuthorize]
        public object CreateEquipment(CreateEquipmentViewModel createEquipmentViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            EquipmentData equipmentData =
                CreateEquipmentViewModel.GetEquipmentData(currentUserInfo.Id, createEquipmentViewModel);

            _equipmentLogic.Add(equipmentData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectEquipmentList(Guid projectId, DateTime reportDate)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            IEnumerable<EquipmentData> equipmentDatas = _equipmentLogic.GetProjectEquipment(projectId, reportDate);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, equipmentDatas.Select(EquipmentViewModel.GetEquipmentViewModel)));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetEquipment(Guid projectId, Guid equipmentId)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            EquipmentData equipmentData = _equipmentLogic.GetEquipment(equipmentId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, EquipmentViewModel.GetEquipmentViewModel(equipmentData)));
        }

        [HttpPost]
        [SuperAuthorize]
        public object EditEquipment(EditEquipmentViewModel editEquipmentViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_equipmentLogic.IsEquipmentExist(editEquipmentViewModel.ProjectId, editEquipmentViewModel.EquipmentId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, editEquipmentViewModel.ProjectId) == UserRole.Collaborator
               && !_equipmentLogic.IsEquipmentCreatedBy(currentUserInfo.Id, editEquipmentViewModel.EquipmentId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            EquipmentData equipmentData =
                EditEquipmentViewModel.GetEquipmentData(editEquipmentViewModel);

            _equipmentLogic.Edit(equipmentData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpPost]
        [SuperAuthorize]
        public object DeleteEquipment(DeleteEquipmentViewModel deleteEquipmentViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_equipmentLogic.IsEquipmentExist(deleteEquipmentViewModel.ProjectId, deleteEquipmentViewModel.EquipmentId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, deleteEquipmentViewModel.ProjectId) == UserRole.Collaborator
                && !_equipmentLogic.IsEquipmentCreatedBy(currentUserInfo.Id, deleteEquipmentViewModel.EquipmentId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            _equipmentLogic.Delete(deleteEquipmentViewModel.EquipmentId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }
    }
}
