using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities.Interfaces
{
    public interface IToolEntity
    {
        public int ToolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Barcode { get; set; }
    }
}
