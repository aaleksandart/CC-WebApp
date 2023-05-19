using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services.Interfaces
{
    public interface IAvailabilityService
    {
        Task<bool> GetAvailability(int toolId);
    }
}
