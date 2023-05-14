using CC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) 
        {

        }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<ToolEntity> Tools { get; set; }
        public virtual DbSet<RentDataEntity> RentData { get; set; }
        public virtual DbSet<AvailbilityEntity> Availability { get; set; }
        public virtual DbSet<EmployeeEntity> Employees { get; set; }
    }
}
