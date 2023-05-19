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
        public AvailbilityEntity()
        {
        }

        public AvailbilityEntity(int toolId, int status)
        {
            ToolId = toolId;
            Status = status;
        }

        public AvailbilityEntity(int toolId, ToolEntity? tool, int status)
        {
            ToolId = toolId;
            Tool = tool;
            Status = status;
        }

        public AvailbilityEntity(int availabilityId, int toolId, ToolEntity? tool, int status)
        {
            AvailabilityId = availabilityId;
            ToolId = toolId;
            Tool = tool;
            Status = status;
        }

        [Key]
        public int AvailabilityId { get; set; }

        [ForeignKey("Tool")]
        public int ToolId { get; set; }
        public ToolEntity? Tool { get; set; }

        public int Status { get; set; }
    }
}
