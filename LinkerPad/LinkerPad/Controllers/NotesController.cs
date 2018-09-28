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
using LinkerPad.Models.Notes;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Controllers
{
    public class NotesController : ApiController
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly INotesLogic _NotesLogic;
        private readonly IProjectLogic _projectLogic;

        public NotesController(
            ITokenHelper tokenHelper,
            INotesLogic NotesLogic,
            IProjectLogic projectLogic)
        {
            _tokenHelper = tokenHelper;
            _NotesLogic = NotesLogic;
            _projectLogic = projectLogic;
        }
        [HttpPost]
        [SuperAuthorize]
        public object CreateNotes(CreateNotesViewModel createNotesViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            NotesData NotesData =
                CreateNotesViewModel.GetNotesData(currentUserInfo.Id, createNotesViewModel);

            _NotesLogic.Add(NotesData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectNotesList(Guid projectId, DateTime reportDate)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            IEnumerable<NotesData> NotesDatas = _NotesLogic.GetProjectNotes(projectId, reportDate);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, NotesDatas.Select(NotesViewModel.GetNotesViewModel)));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetNotes(Guid projectId, Guid NotesId)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            NotesData NotesData = _NotesLogic.GetNotes(NotesId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, NotesViewModel.GetNotesViewModel(NotesData)));
        }

        [HttpPost]
        [SuperAuthorize]
        public object EditNotes(EditNotesViewModel editNotesViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_NotesLogic.IsNotesExist(editNotesViewModel.ProjectId, editNotesViewModel.NotesId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, editNotesViewModel.ProjectId) == UserRole.Collaborator
               && !_NotesLogic.IsNotesCreatedBy(currentUserInfo.Id, editNotesViewModel.NotesId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            NotesData NotesData =
                EditNotesViewModel.GetNotesData(editNotesViewModel);

            _NotesLogic.Edit(NotesData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpPost]
        [SuperAuthorize]
        public object DeleteNotes(DeleteNotesViewModel deleteNotesViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_NotesLogic.IsNotesExist(deleteNotesViewModel.ProjectId, deleteNotesViewModel.NotesId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, deleteNotesViewModel.ProjectId) == UserRole.Collaborator
                && !_NotesLogic.IsNotesCreatedBy(currentUserInfo.Id, deleteNotesViewModel.NotesId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            _NotesLogic.Delete(deleteNotesViewModel.NotesId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }
    }
}
