using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities.Interfaces
{
    public interface IEmployeeEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

    }
}
