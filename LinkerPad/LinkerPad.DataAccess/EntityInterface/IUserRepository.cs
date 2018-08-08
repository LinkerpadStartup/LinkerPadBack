using LinkerPad.Data;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.EntityInterface
{
    public interface IUserRepository : IRepository<UserData>
    {
        UserData GetUserByUsername(string username);
    }
}