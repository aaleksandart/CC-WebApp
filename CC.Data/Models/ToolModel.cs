using CC.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Models
{
    public class ToolModel : IToolModel
    {
        public ToolModel()
        {
        }
        public ToolModel(string name, string description, Guid barcode)
        {
            Name = name;
            Description = description;
            Barcode = barcode;
        }

        public ToolModel(int id, string name, string description, Guid barcode)
        {
            Id = id;
            Name = name;
            Description = description;
            Barcode = barcode;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid Barcode { get; set; }
    }
}
