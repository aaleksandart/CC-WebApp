using CC.Data.Context;
using CC.Data.Entities;
using CC.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlContext _sql;
        public EmployeeRepository(SqlContext sql)
        {
            _sql = sql;
        }

        public async Task<bool> CreateEmployee(EmployeeEntity entity)
        {
            try
            {
                await _sql.Employees.AddAsync(entity);
                await _sql.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }

        public async Task<EmployeeEntity> GetEmployee(int id)
        {
            var entity = new EmployeeEntity();
            try
            {
                entity = await _sql.FindAsync<EmployeeEntity>(id);
            }
            catch
            {
                return entity;
            }
            return entity;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            var entities = new List<EmployeeEntity>();
            try
            {
                entities = await _sql.Employees.ToListAsync();
            }
            catch
            {
                return entities;
            }
            return entities;
        }
    }
}
