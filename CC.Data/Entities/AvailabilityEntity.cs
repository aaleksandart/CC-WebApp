using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Data.Entities.Interfaces;

namespace CC.Data.Entities
{
    public class AvailbilityEntity : IAvailabilityEntity
    {
        [Key]
        public int AvailabilityId { get; set; }

        [ForeignKey("Tool")]
        public int ToolId { get; set; }
        public ToolEntity? Tool { get; set; }

        public int Status { get; set; }
    }
}
