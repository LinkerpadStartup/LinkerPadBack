using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinkerPad.Common.CustomeAuthorizeAttribute;
using LinkerPad.Models.Account;
using LinkerPad.Models.Response;

namespace LinkerPad.Controllers
{
    public class AccountController : ApiController
    {
        public AccountController()
        {
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
        [SuperAuthorize]
        public object Logout()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
