using CC.Data.Context;
using CC.Data.Entities;
using CC.Data.Models;
using CC.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories
{
    public class RentDataRepository : IRentDataRepository
    {
        private readonly SqlContext _sql;
        public RentDataRepository(SqlContext sql)
        {
            _sql = sql;
        }

        public async Task<bool> CreateRentData(RentDataModel model)
        {
            if (model == null)
                return false;
            var entity = new RentDataEntity(model.ToolId, model.UserId, model.RentStart, model.RentEnd);
            try
            {
                await _sql.RentData.AddAsync(entity);
                await _sql.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }
        public async Task<bool> UpdateRentData()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<RentDataEntity>> GetAllRentData()
        {
            var rentdata = new List<RentDataEntity>();
            try
            {
                rentdata = await _sql.RentData.ToListAsync();
            }
            catch { }
            return rentdata;
        }
        public async Task<IEnumerable<RentDataEntity>> GetRentDataByEmail(string email)
        {
            var rentdata = new List<RentDataEntity>();
            try
            {
                rentdata = await _sql.RentData.Include(rd => rd.User).Include(rd => rd.Tool).Where(rd => rd.User.EmailAddress == email).ToListAsync();
            }
            catch { }
            return rentdata;
        }
    }
}
