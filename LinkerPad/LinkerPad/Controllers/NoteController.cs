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
using LinkerPad.Models.Note;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Controllers
{
    public class NoteController : ApiController
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly INoteLogic _noteLogic;
        private readonly IProjectLogic _projectLogic;

        public NoteController(
            ITokenHelper tokenHelper,
            INoteLogic noteLogic,
            IProjectLogic projectLogic)
        {
            _tokenHelper = tokenHelper;
            _noteLogic = noteLogic;
            _projectLogic = projectLogic;
        }
        [HttpPost]
        [SuperAuthorize]
        public object CreateNote(CreateNoteViewModel createNoteViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            NoteData noteData =
                CreateNoteViewModel.GetNoteData(currentUserInfo.Id, createNoteViewModel);

            _noteLogic.Add(noteData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetProjectNoteList(Guid projectId, DateTime reportDate)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            IEnumerable<NoteData> noteDatas = _noteLogic.GetProjectNote(projectId, reportDate);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, noteDatas.Select(NoteViewModel.GetNoteViewModel)));
        }

        [HttpGet]
        [SuperAuthorize]
        public object GetNote(Guid projectId, Guid noteId)
        {
            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_projectLogic.IsProjectExist(currentUserInfo.Id, projectId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.ProjectNotFound));

            NoteData noteData = _noteLogic.GetNote(noteId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success, NoteViewModel.GetNoteViewModel(noteData)));
        }

        [HttpPost]
        [SuperAuthorize]
        public object EditNote(EditNoteViewModel editNoteViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_noteLogic.IsNoteExist(editNoteViewModel.ProjectId, editNoteViewModel.NoteId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, editNoteViewModel.ProjectId) == UserRole.Collaborator
               && !_noteLogic.IsNoteCreatedBy(currentUserInfo.Id, editNoteViewModel.NoteId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            NoteData noteData =
                EditNoteViewModel.GetNoteData(editNoteViewModel);

            _noteLogic.Edit(noteData);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }

        [HttpPost]
        [SuperAuthorize]
        public object DeleteNote(DeleteNoteViewModel deleteNoteViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            CurrentUserInfo currentUserInfo = _tokenHelper.GetUserInfo();

            if (!_noteLogic.IsNoteExist(deleteNoteViewModel.ProjectId, deleteNoteViewModel.NoteId))
                return Request.CreateResponse(HttpStatusCode.NotFound, new BaseResponse(ResponseStatus.Notfound.ToString(), ResponseMessagesModel.DailyActiviyNotFound));

            if (_projectLogic.GetUserRoleInProject(currentUserInfo.Id, deleteNoteViewModel.ProjectId) == UserRole.Collaborator
                && !_noteLogic.IsNoteCreatedBy(currentUserInfo.Id, deleteNoteViewModel.NoteId))
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.PermissionDenied));

            _noteLogic.Delete(deleteNoteViewModel.NoteId);

            return Request.CreateResponse(HttpStatusCode.OK, new BaseResponse(ResponseStatus.Success.ToString(),
                ResponseMessagesModel.Success));
        }
    }
}
