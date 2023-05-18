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
        private readonly IToolsRepository _repository;
        public ToolService(IToolsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddTool(ToolModel model)
        {
            if (model == null)
                return false;
            try
            {
                var entity = new ToolEntity(model.Name, model.Description, model.Barcode);
                await _repository.CreateTool(entity);
            }
            catch { return false; }
            return true;
        }

        public async Task<IEnumerable<ToolModel>> GetAllTools()
        {
            var entities = (List<ToolEntity>)await _repository.GetTools();
            if (entities == null)
                return new List<ToolModel>();
            
            var models = new List<ToolModel>();
            foreach (var entity in entities)
            {
                models.Add(MapEntityToModel(entity));
            }
            return models;
        }

        public Task<ToolModel> GetToolById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToolInfo(ToolModel model)
        {
            throw new NotImplementedException();
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
