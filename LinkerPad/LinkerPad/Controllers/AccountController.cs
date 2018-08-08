using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Common;
using LinkerPad.Data;
using LinkerPad.Models.Account;
using LinkerPad.Models.Response;

namespace LinkerPad.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountLogic _accountLogic;
        private readonly ITokenHelper _tokenHelper;

        public AccountController(IAccountLogic accountLogic, ITokenHelper tokenHelper)
        {
            _accountLogic = accountLogic;
            _tokenHelper = tokenHelper;
        }

        [HttpPost]
        [AllowAnonymous]
        public object Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            UserData userData = RegisterViewModel.GetUserData(registerViewModel);

            _accountLogic.Add(userData);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [AllowAnonymous]
        public object Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            if (!_accountLogic.IsUserExist(loginViewModel.Username, HashManagement.Md5Hash(loginViewModel.Password)))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ResponseMessagesModel.UsernameOrPassIsWrong));

            UserData userData = _accountLogic.GetUser(loginViewModel.Username);

            return _tokenHelper.CreateUserToken(userData);
        }
    }
}
