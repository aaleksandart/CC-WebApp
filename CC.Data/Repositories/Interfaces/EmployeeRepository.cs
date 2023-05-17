using CC.Data.Context;
using CC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories.Interfaces
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
    }
}
