using CC.Data.Entities;
using CC.Data.Models;
using CC.Data.Repositories.Interfaces;
using CC.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddUser(UserModel model)
        {
            try
            {
                if (!await CheckUserExist(model.EmailAddress))
                {
                    var entity = new UserEntity(model.UserName, model.EmailAddress, model.Name);
                    var success = await _userRepository.CreateUser(entity);
                    if (!success)
                        return false;
                }
                else
                    return false;
            }
            catch { return false; }
            return true;

        }

        public Task<IEnumerable<UserModel>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserInfo(UserModel model)
        {
            throw new NotImplementedException();
        }

        #region Private methods

        private async Task<bool> CheckUserExist(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }
        #endregion
    }
}
