using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities.Interfaces
{
    public interface IRentDataEntity
    {
        public int RentDataId { get; set; }
        public int ToolId { get; set; }
        public ToolEntity? Tool { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
    }
}
