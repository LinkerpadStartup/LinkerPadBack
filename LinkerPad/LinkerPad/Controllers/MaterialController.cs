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
using LinkerPad.Models.Material;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Controllers
{
    public class MaterialController : ApiController
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IMaterialLogic _materialLogic;
        private readonly IProjectLogic _projectLogic;

        public MaterialController(
            ITokenHelper tokenHelper,
            IMaterialLogic materialLogic,
            IProjectLogic projectLogic)
        {
            _tokenHelper = tokenHelper;
            _materialLogic = materialLogic;
            _projectLogic = projectLogic;
        }
        [HttpPost]
        [SuperAuthorize]
        public object CreateMaterial(CreateMaterialViewModel createMaterialViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            MaterialData materialData =
                CreateMaterialViewModel.GetMaterialData(currentUserInfo.Id, createMaterialViewModel);

            _materialLogic.Add(materialData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectMaterialList(Guid projectId, DateTime reportDate)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            IEnumerable<MaterialData> materialDatas = _materialLogic.GetProjectMaterials(projectId, reportDate);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, materialDatas.Select(MaterialViewModel.GetMaterialViewModel)));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetMaterial(Guid projectId, Guid materialId)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            MaterialData materialData = _materialLogic.GetMaterial(materialId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, MaterialViewModel.GetMaterialViewModel(materialData)));
        }

        [HttpPost]
        [SuperAuthorize]
        public object EditMaterial(EditMaterialViewModel editMaterialViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_materialLogic.IsMaterialExist(editMaterialViewModel.ProjectId, editMaterialViewModel.MaterialId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, editMaterialViewModel.ProjectId) == UserRole.Collaborator
               && !_materialLogic.IsMaterialCreatedBy(currentUserInfo.Id, editMaterialViewModel.MaterialId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            MaterialData materialData =
                EditMaterialViewModel.GetMaterialData(editMaterialViewModel);

            _materialLogic.Edit(materialData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpPost]
        [SuperAuthorize]
        public object DeleteMaterial(DeleteMaterialViewModel deleteMaterialViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_materialLogic.IsMaterialExist(deleteMaterialViewModel.ProjectId, deleteMaterialViewModel.MaterialId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, deleteMaterialViewModel.ProjectId) == UserRole.Collaborator
                && !_materialLogic.IsMaterialCreatedBy(currentUserInfo.Id, deleteMaterialViewModel.MaterialId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            _materialLogic.Delete(deleteMaterialViewModel.MaterialId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }
    }
}
