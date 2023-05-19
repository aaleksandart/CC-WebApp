using CC.Data.Entities;
using CC.Data.Models;
using CC.Data.Repositories.Interfaces;
using CC.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services
{
    public class RentDataService : IRentDataService
    {
        private readonly IRentDataRepository _rentDataRepository;
        public RentDataService(IRentDataRepository rentDataRepository)
        {
            _rentDataRepository = rentDataRepository;
        }
        public async Task<IEnumerable<RentDataModel>> GetRentDataByEmail(string email)
        {
            var modelList = new List<RentDataModel>();
            var rentDataEntities = await _rentDataRepository.GetRentDataByEmail(email);
            foreach (var rentdata in rentDataEntities)
            {
                modelList.Add(MapEntityToModel(rentdata));
            }
            return modelList;
        }
        public async Task<IEnumerable<RentDataModel>> GetCurrentRentData(string email)
        {
            var rentdatamodels = new List<RentDataModel>();
            foreach (var data in await _rentDataRepository.GetFilteredRentData(email, "current"))
            {
                rentdatamodels.Add(MapEntityToModel(data));
            }
            return rentdatamodels;
        }
        public async Task<IEnumerable<RentDataModel>> GetRentHistory(string email)
        {
            var rentdatamodels = new List<RentDataModel>();
            foreach (var data in await _rentDataRepository.GetFilteredRentData(email, "history"))
            {
                rentdatamodels.Add(MapEntityToModel(data));
            }
            return rentdatamodels;
        }

        #region Private methods
        private RentDataModel MapEntityToModel(RentDataEntity entity)
        {
            var model = new RentDataModel(entity.RentDataId, entity.ToolId, entity.Tool, entity.UserId, entity.User, entity.RentStart, entity.RentEnd);
            return model;
        }

        #endregion
    }
}
