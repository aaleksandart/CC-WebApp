using CC.Data.Context;
using CC.Data.Entities.Interfaces;
using CC.Data.Repositories.Interfaces;
using CC.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        public AvailabilityService(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<bool> GetAvailability(int toolId)
        {
            if (toolId == 0)
                return false;

            var available = await _availabilityRepository.GetAvailability(toolId);
            if(available == null || available.Status == 0)
                return false;
            return true;
        }
    }
}
