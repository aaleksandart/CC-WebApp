using CC.Data.Context;
using CC.Data.Entities;
using CC.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlContext _sql;
        public UserRepository(SqlContext sql)
        {
            _sql = sql;
        }

        public async Task<bool> CreateUser(UserEntity user)
        {
            try
            {
                await _sql.AddAsync(user);
                await _sql.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }
        public async Task<UserEntity> GetUser(int id)
        {
            var user = new UserEntity();
            try
            {
                user = await _sql.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
            }
            catch { return user; }
            return user;
        }
        public async Task<bool> GetUserByEmail(string email)
        {
            try
            {
                var exists = await _sql.Users.Where(u => u.EmailAddress == email).FirstOrDefaultAsync();
                if (exists == null)
                    return false;
            }
            catch {  }
            return true;
        }
        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            var users = new List<UserEntity>();
            try
            {
                users =  await _sql.Users.ToListAsync();
            }
            catch { return users; }
            return users;
        }
        public async Task<bool> UpdateUser(int id, UserEntity updatedUser)
        {
            try
            {
                var existingUser = await _sql.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
                if (existingUser == null)
                    return false;
                //Do the actual update
            }
            catch { return false; }
            return true;
        }
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _sql.Users.FindAsync(id);
                if (user != null)
                    _sql.Users.Remove(user);
                else
                    return false;
            }
            catch { return false; }
            return true;
        }
    }
}
