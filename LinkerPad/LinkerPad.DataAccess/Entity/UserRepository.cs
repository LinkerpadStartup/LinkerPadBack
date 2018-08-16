using System.Linq;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    internal class UserRepository : Repository<UserData>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public UserData GetUserByUsername(string username)
        {
            return GetAll().FirstOrDefault(u => u.Email == username);
        }
    }
}
