using CC.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities
{
    public class ToolEntity : IToolEntity
    {
        public ToolEntity()
        {
        }
        [Key]
        public int ToolId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid Barcode { get; set; }
    }
}
