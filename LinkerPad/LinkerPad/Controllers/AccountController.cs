using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Common.CustomeAuthorizeAttribute;
using LinkerPad.Data;
using LinkerPad.Models.Account;
using LinkerPad.Models.Response;

namespace LinkerPad.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountLogic _accountLogic;

        public AccountController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        [HttpPost]
        [AllowAnonymous]
        public object Register(RegisterViewModel registerViewModel)
        {

            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        public object Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new BaseResponse(ResponseStatus.ValidationError.ToString(), ModelState.Values.ToList()[0].Errors[0].ErrorMessage));

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        //[SuperAuthorize]
        public object Logout()
        {
            bool result = _accountLogic.IsUserExist(Guid.Parse("b88e7dc3-bb61-472e-8a70-a935012d51db"));
            UserData userData = _accountLogic.GetUser(Guid.Parse("b88e7dc3-bb61-472e-8a70-a935012d51cb"));
            _accountLogic.Add(new UserData
            {
                Id = Guid.NewGuid()
            });
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
