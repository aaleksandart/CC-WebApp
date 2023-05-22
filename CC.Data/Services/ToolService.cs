using CC.Data.Entities;
using CC.Data.Entities.Interfaces;
using CC.Data.Models;
using CC.Data.Repositories;
using CC.Data.Repositories.Interfaces;
using CC.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Services
{
    public class ToolService : IToolService
    {
        private readonly IToolsRepository _toolRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IRentDataRepository _rentDataRepository;
        private readonly IUserRepository _userRepository;
        public ToolService(IToolsRepository toolRepository, IAvailabilityRepository availabilityRepository, IRentDataRepository rentDataRepository, IUserRepository userRepository)
        {
            _toolRepository = toolRepository;
            _availabilityRepository = availabilityRepository;
            _rentDataRepository = rentDataRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> AddTool(ToolModel model)
        {
            if (model == null)
                return false;
            try
            {
                var entity = new ToolEntity(model.Name, model.Description, model.Barcode);
                var success = await _toolRepository.CreateTool(entity);
                if (success)
                {
                    var availabilityEntity = new AvailbilityEntity(entity.ToolId, 1);
                    await _availabilityRepository.CreateAvailability(availabilityEntity);
                }
            }
            catch { return false; }
            return true;
        }

        public async Task<IEnumerable<ToolModel>> GetAllTools()
        {
            var entities = (List<ToolEntity>)await _toolRepository.GetTools();
            if (entities == null)
                return new List<ToolModel>();
            
            var models = new List<ToolModel>();
            foreach (var entity in entities)
            {
                models.Add(MapEntityToModel(entity));
            }
            return models;
        }

        public async Task<ToolModel> GetToolById(int id)
        {
            var model = new ToolModel();
            var entity = await _toolRepository.GetTool(id);
            if (entity != null)
                model = MapEntityToModel(entity);
            return model;
        }

        public Task<bool> UpdateToolInfo(ToolModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RentTool(int toolId, string email)
        {
            if (toolId != 0 && email != null)
            {
                var tool = await _toolRepository.GetTool(toolId);
                var user = await _userRepository.GetUserByEmail(email);
                var available = await _availabilityRepository.GetAvailability(toolId);
                var date = DateTime.Now;
                if (available == null || available.Status == 0)
                    return false;

                var rentDataModel = new RentDataModel(tool.ToolId, tool, user.UserId, user, date, date.AddDays(5));
                try
                {
                    var rentDataEntity = await _rentDataRepository.CreateRentData(rentDataModel);
                    if (rentDataEntity)
                        await _availabilityRepository.UpdateAvailability(toolId, 0);
                }
                catch { return false; }
                return true;
            }
            else
                return false;
        }

        #region Private methods
        private ToolModel MapEntityToModel(ToolEntity entity)
        {
            var model = new ToolModel(entity.ToolId, entity.Name, entity.Description, entity.Barcode);
            return model;
        }

        #endregion
    }
}
