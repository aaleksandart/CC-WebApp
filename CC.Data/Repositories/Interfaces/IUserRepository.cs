using CC.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(UserEntity user);
        Task<UserEntity> GetUser(int id);
        Task<bool> GetUserByEmail(string email);
        Task<IEnumerable<UserEntity>> GetUsers();
        Task<bool> UpdateUser(int id, UserEntity user);
        Task<bool> DeleteUser(int id);
    }
}
