using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using LinkerPad.Business.BusinessLogic;
using LinkerPad.Business.BusinessLogicInterface;

namespace LinkerPad.Common.CustomeAuthorizeAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SuperAuthorize : AuthorizeAttribute
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IAccountLogic _accountLogic;

        public SuperAuthorize()
        {
            _tokenHelper = new TokenHelper();
            _accountLogic = new AccountLogic();
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UID"];
            if (cookie != null)
            {
                string token = cookie.Value;

                if (string.IsNullOrWhiteSpace(token))
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }

                else if (!_tokenHelper.IsTokenValid(token))
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }

                else if (_accountLogic.GetUser(_tokenHelper.GetUserInfo().Username).IsDisabled)
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}