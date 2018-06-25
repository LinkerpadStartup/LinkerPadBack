using LinkerPad.Data;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Common
{
    public interface ITokenHelper
    {
        bool IsTokenValid(string token);

        CurrentUserInfo GetUserInfo();

        void CreateCookie(UserData userData);

        void ExpireUserCookie();       
    }
}
