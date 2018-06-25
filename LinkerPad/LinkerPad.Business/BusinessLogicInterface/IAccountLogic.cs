using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IAccountLogic
    {
        UserData GetUser(string userName);

        UserData GetUser(Guid userId);

        IEnumerable<UserData> GetUserList(bool getAll, int objectPerPage = 0, int pageNumber = 0);

        IEnumerable<UserData> GetUserList(string userSearch, bool getAll, int objectPerPage = 0, int pageNumber = 0);

        void Add(UserData userData);

        int UserCount();

        int UserCount(string userSearch);

        bool IsUserExist(string userName);

        bool IsUserExist(Guid userId);
    }
}
