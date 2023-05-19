using CC.Data.Entities;
using CC.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Models
{
    public class RentDataModel : IRentDataModel
    {
        public RentDataModel()
        {
        }

        public RentDataModel(int toolId, int userId, DateTime rentStart, DateTime rentEnd)
        {
            ToolId = toolId;
            UserId = userId;
            RentStart = rentStart;
            RentEnd = rentEnd;
        }

        public RentDataModel(int toolId, ToolEntity? tool, int userId, UserEntity? user, DateTime rentStart, DateTime rentEnd)
        {
            ToolId = toolId;
            Tool = tool;
            UserId = userId;
            User = user;
            RentStart = rentStart;
            RentEnd = rentEnd;
        }

        public RentDataModel(int rentDataId, int toolId, ToolEntity? tool, int userId, UserEntity? user, DateTime rentStart, DateTime rentEnd)
        {
            RentDataId = rentDataId;
            ToolId = toolId;
            Tool = tool;
            UserId = userId;
            User = user;
            RentStart = rentStart;
            RentEnd = rentEnd;
        }

        public int RentDataId { get; set; }
        public int ToolId { get; set; }
        public ToolEntity? Tool { get; set; }
        public int UserId { get; set; }
        public UserEntity? User { get; set; }

        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
    }
}
