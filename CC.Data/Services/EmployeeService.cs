using CC.Data.Entities;
using CC.Data.Models;
using CC.Data.Repositories.Interfaces;
using CC.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddEmployee(EmployeeModel model)
        {
            if (model == null)
                return false;
            try
            {
                var entity = new EmployeeEntity(model.Name, model.Role);
                await _repository.CreateEmployee(entity);
            }
            catch { return false; }
            return true;
        }
    }
}
