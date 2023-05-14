using CC.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities
{
    public class RentDataEntity : IRentDataEntity
    {
        [Key]
        public int RentDataId { get; set; }

        [ForeignKey("Tool")]
        public int ToolId { get; set; }
        public ToolEntity? Tool { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity? User { get; set; }

        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
    }
}
