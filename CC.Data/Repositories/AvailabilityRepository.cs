using CC.Data.Context;
using CC.Data.Entities;
using CC.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly SqlContext _sql;
        public AvailabilityRepository(SqlContext sql)
        {
            _sql = sql;
        }
        public async Task<bool> CreateAvailability(AvailbilityEntity entity)
        {
            try
            {
                var exist = await _sql.Availability.Where(a => a.ToolId == entity.ToolId).FirstOrDefaultAsync();
                if (exist != null)
                    return false;

                await _sql.Availability.AddAsync(entity);
                await _sql.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<AvailbilityEntity> GetAvailability(int toolId)
        {
            var entity = new AvailbilityEntity();
            try
            {
                entity = await _sql.Availability.Where(a => a.ToolId == toolId).FirstOrDefaultAsync();
            }
            catch { }
            return entity;
        }
        public async Task<bool> UpdateAvailability(int toolId, int status)
        {
            var entity = new AvailbilityEntity();
            if (toolId == 0)
                return false;
            try
            {
                entity = await _sql.Availability.Where(a => a.ToolId == toolId).FirstOrDefaultAsync();
                entity.Status = status;
                if (entity == null)
                    return false;

                _sql.Update(entity);
                await _sql.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
            
        }
    }
}
