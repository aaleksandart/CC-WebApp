using CC.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories.Interfaces
{
    public interface IToolsRepository
    {
        Task<bool> CreateTool(ToolEntity tool);
        Task<ToolEntity> GetTool(int id);
        Task<IEnumerable<ToolEntity>> GetTools();
        Task<bool> UpdateTool(int id, ToolEntity tool);
        Task<bool> DeleteTool(int id);
    }
}
