using CC.Data.Entities;
using CC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories.Interfaces
{
    public interface IRentDataRepository
    {
        Task <bool> CreateRentData(RentDataModel model);
        Task <bool> UpdateRentData();
        Task<IEnumerable<RentDataEntity>> GetAllRentData();
        Task<IEnumerable<RentDataEntity>> GetRentDataByEmail(string email);
        Task<IEnumerable<RentDataEntity>> GetFilteredRentData(string email, string filter);
    }
}
