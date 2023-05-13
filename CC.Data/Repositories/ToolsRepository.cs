using CC.Data.Context;
using CC.Data.Entities;
using CC.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories
{
    public class ToolsRepository : IToolsRepository
    {
        private readonly SqlContext _sql;
        public ToolsRepository(SqlContext sql)
        {
            _sql = sql;
        }
        public async Task<bool> CreateTool(ToolEntity tool)
        {
            try
            {
                await _sql.AddAsync(tool);
                await _sql.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }
        public async Task<ToolEntity> GetTool(int id)
        {
            var tool = new ToolEntity();
            try
            {
                tool = await _sql.Tools.Where(u => u.ToolId == id).FirstOrDefaultAsync();
            }
            catch { return tool; }
            return tool;
        }
        public async Task<IEnumerable<ToolEntity>> GetTools()
        {
            var tools = new List<ToolEntity>();
            try
            {
                tools = await _sql.Tools.ToListAsync();
            }
            catch { return tools; }
            return tools;
        }
        public async Task<bool> UpdateTool(int id, ToolEntity updateTool)
        {
            try
            {
                var existingTool = await _sql.Tools.Where(u => u.ToolId == id).FirstOrDefaultAsync();
                if (existingTool == null)
                    return false;
                //Do the actual update
            }
            catch { return false; }
            return true;
        }
        public async Task<bool> DeleteTool(int id)
        {
            try
            {
                var tool = await _sql.Tools.FindAsync(id);
                if (tool != null)
                    _sql.Tools.Remove(tool);
                else
                    return false;
            }
            catch { return false; }
            return true;
        }
    }
}
