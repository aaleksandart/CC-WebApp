using CC.Data.Entities;
using CC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services.Interfaces
{
    public interface IRentDataService
    {
        Task<IEnumerable<RentDataModel>> GetRentDataByEmail(string email);
        Task<IEnumerable<RentDataModel>> GetCurrentRentData(string email);
        Task<IEnumerable<RentDataModel>> GetRentHistory(string email);
    }
}
