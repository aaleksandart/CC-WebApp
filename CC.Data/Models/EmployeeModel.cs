﻿using CC.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Models
{
    public class EmployeeModel : IEmployeeModel
    {
        public EmployeeModel()
        {
        }

        public EmployeeModel(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
