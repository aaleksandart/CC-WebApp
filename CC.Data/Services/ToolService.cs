using CC.Data.Entities.Interfaces;
using CC.Data.Models;
using CC.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services
{
    public class ToolService : IToolService
    {
        public Task<bool> AddTool(ToolModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToolModel>> GetAllTools()
        {
            throw new NotImplementedException();
        }

        public Task<ToolModel> GetToolById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToolInfo(ToolModel model)
        {
            throw new NotImplementedException();
        }
    }
}
