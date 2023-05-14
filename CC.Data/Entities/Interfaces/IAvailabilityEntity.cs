using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities.Interfaces
{
    public interface IAvailabilityEntity
    {
        public int AvailabilityId { get; set; }
        public int ToolId { get; set; }
        public ToolEntity? Tool { get; set; }
        public int Status { get; set; }
    }
}
