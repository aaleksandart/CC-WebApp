﻿using CC.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities
{
    public class EmployeeEntity : IEmployeeEntity
    {
        public EmployeeEntity()
        {
        }

        public EmployeeEntity(string name, string role)
        {
            Name = name;
            Role = role;
        }

        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
