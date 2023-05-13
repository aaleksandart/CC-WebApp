using CC.Data.Entities;
using CC.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddUser(UserModel model);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<bool> UpdateUserInfo(UserModel model);
        Task<bool> RemoveUser(int id);
    }
}
