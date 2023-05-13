using CC.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Models
{
    public class UserModel : IUserModel
    {
        public UserModel()
        {
        }
        public UserModel(string userName, string emailAddress, string name)
        {
            UserName = userName;
            EmailAddress = emailAddress;
            Name = name;
        }

        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
