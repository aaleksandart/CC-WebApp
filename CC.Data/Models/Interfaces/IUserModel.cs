﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Models.Interfaces
{
    public interface IUserModel
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
    }
}
