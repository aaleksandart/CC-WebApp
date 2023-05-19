using CC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Repositories.Interfaces
{
    public interface IAvailabilityRepository
    {
        Task<bool> CreateAvailability(AvailbilityEntity entity);
        Task<AvailbilityEntity> GetAvailability(int toolId);
        Task<bool> UpdateAvailability(int toolId, int status);
    }
}
