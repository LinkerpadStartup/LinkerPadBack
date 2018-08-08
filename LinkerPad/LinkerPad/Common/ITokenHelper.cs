using LinkerPad.Data;
using LinkerPad.Models.Account;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Common
{
    public interface ITokenHelper
    {
        CurrentUserInfo GetUserInfo();

        TokenInformationViewModel CreateUserToken(UserData userData);

        void CreateCookie(UserData userData);

        void ExpireUserCookie();

        bool IsTokenValid(string token);
    }
}
