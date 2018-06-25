using System;
using System.Linq;
using LinkerPad.DataAccess.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    public class UserRepository :
            GenericRepository<LinkerPadDb, Tbl_User>, IUserRepository
    {
        public Tbl_User GetUserById(Guid userId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == userId);
            return query;
        }

        public Tbl_User GetUserByUserName(string username)
        {
            var query = GetAll().FirstOrDefault(x => x.Username == username);
            return query;
        }

        public bool IsUserNameExist(string username)
        {
            var query = GetAll().Any(x => x.Username == username);
            return query;
        }
    }
}
