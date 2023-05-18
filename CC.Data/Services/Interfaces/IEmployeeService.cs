using CC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> AddEmployee(EmployeeModel model);
        Task<IEnumerable<EmployeeModel>> GetAllEmployees();
        Task<EmployeeModel> GetEmployeeById(int id);
    }
}
