using CC.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities
{
    public class UserEntity : IUserEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(string userName, string emailAddress, string name)
        {
            UserName = userName;
            EmailAddress = emailAddress;
            Name = name;
        }

        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
