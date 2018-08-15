using System;
using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class AccountLogic : IAccountLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountLogic(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(UserData userData)
        {
            _unitOfWork.BeginTransaction();

            _userRepository.Create(userData);

            _unitOfWork.Commit();
        }

        public void Edit(UserData userData)
        {
            _unitOfWork.BeginTransaction();

            _userRepository.Update(userData);

            _unitOfWork.Commit();
        }

        public UserData GetUser(string userName)
        {
            return _userRepository.GetUserByUsername(userName);
        }

        public UserData GetUser(Guid userId)
        {
            return _userRepository.GetById(userId);
        }

        public IEnumerable<UserData> GetUserList(bool getAll, int objectPerPage = 0, int pageNumber = 0)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserData> GetUserList(string userSearch, bool getAll, int objectPerPage = 0, int pageNumber = 0)
        {
            throw new NotImplementedException();
        }

        public int UserCount()
        {
            throw new NotImplementedException();
        }

        public int UserCount(string userSearch)
        {
            throw new NotImplementedException();

        }

        public bool IsUserExist(string userName)
        {
            return _userRepository.GetAll().Any(u => u.Email == userName);
        }

        public bool IsUserExist(Guid userId)
        {
            return _userRepository.GetAll().Any(u => u.Id == userId);
        }

        public bool IsUserExist(string email, string hashedPassword)
        {
            return _userRepository.GetAll().Any(u => u.Email == email && u.Password == hashedPassword);
        }
    }
}
