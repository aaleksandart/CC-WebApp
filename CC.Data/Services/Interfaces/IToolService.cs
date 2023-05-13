using CC.Data.Entities;
using CC.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services.Interfaces
{
    public interface IToolService
    {
        Task<bool> AddTool(ToolModel model);
        Task<bool> UpdateToolInfo(ToolModel model);
        Task<IEnumerable<ToolModel>> GetAllTools();
        Task<ToolModel> GetToolById(int id);
    }
}
