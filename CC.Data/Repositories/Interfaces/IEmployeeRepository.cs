using CC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> CreateEmployee(EmployeeEntity entity);
    }
}
