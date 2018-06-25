using System;
using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.Entity;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Data;

namespace LinkerPad.Business.BusinessLogic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IUserRepository _userRepository;

        public AccountLogic()
        {
            _userRepository = new UserRepository();
        }

        public void Add(UserData userData)
        {
            Tbl_User userDataSource = UserData.GetUserDataSource(userData);

            _userRepository.Add(userDataSource);

            _userRepository.Save();
        }

        public bool IsUserExist(string userName)
        {
            return _userRepository.GetAll().Any(u => u.Username == userName);
        }

        public UserData GetUser(string userName)
        {
            Tbl_User userDataSource = _userRepository.FindBy(u => u.Username == userName).FirstOrDefault();
            return UserData.GetUserData(userDataSource);
        }

        public UserData GetUser(Guid userId)
        {
            Tbl_User userDataSource = _userRepository.FindBy(u => u.Id == userId).FirstOrDefault();
            return UserData.GetUserData(userDataSource);
        }

        public IEnumerable<UserData> GetUserList(bool getAll, int objectPerPage = 0, int pageNumber = 0)
        {
            IQueryable<Tbl_User> userDataSources;
            if (!getAll)
            {
                userDataSources = _userRepository.GetAll().OrderByDescending(p => p.CreateDate)
                    .Skip(objectPerPage * pageNumber).Take(objectPerPage);
            }
            else
            {
                userDataSources = _userRepository.GetAll().OrderByDescending(p => p.CreateDate);
            }

            return userDataSources.AsEnumerable().Select(UserData.GetUserData);
        }

        public IEnumerable<UserData> GetUserList(string userSearch, bool getAll, int objectPerPage = 0, int pageNumber = 0)
        {
            IQueryable<Tbl_User> usersDataSource = _userRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(userSearch))
                usersDataSource = usersDataSource.Where(t =>
                    t.Username.Contains(userSearch));

            if (getAll)
                return usersDataSource.Select(UserData.GetUserData);

            usersDataSource = usersDataSource
                .OrderByDescending(p => p.CreateDate)
                .Skip(objectPerPage * pageNumber).Take(objectPerPage);

            return usersDataSource.Select(UserData.GetUserData);
        }

        public int UserCount()
        {
            return _userRepository.GetAll().Count();
        }

        public int UserCount(string userSearch)
        {
            IQueryable<Tbl_User> usersDataSource = _userRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(userSearch))
                usersDataSource = usersDataSource.Where(t =>
                        t.Username.Contains(userSearch));

            return usersDataSource.Count();
        }

        public bool IsUserExist(Guid userId)
        {
            return _userRepository.GetAll().Any(u => u.Id == userId);
        }
    }
}
