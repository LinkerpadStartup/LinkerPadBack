using System;
using LinkerPad.DataAccess.Data;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.EntityInterface
{
    public interface IUserRepository : IGenericRepository<Tbl_User>
    {
        Tbl_User GetUserById(Guid userId);

        Tbl_User GetUserByUserName(string username);

        bool IsUserNameExist(string username);
    }
}
