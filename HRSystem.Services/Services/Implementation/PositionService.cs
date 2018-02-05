using System;
using System.Linq;
using HRSystem.DataAccess.Entity;
using HRSystem.DataAccess.Repository;
using HRSystem.Domain.Domains;
using static HRSystem.Service.Tools.ServiceMapper;

namespace HRSystem.Service.Services.Implementation
{
    public class PositionService : IPositionService
    {
        public PositionService(IRepository<Position> rep)
        {
            repository = rep;
        }

        private readonly IRepository<Position> repository;

        public Guid Add(PositionModel item)
        {
            var position = Mapper.Map<PositionModel, Position>(item);
            return repository.Add(position);
        }

        public IQueryable<PositionModel> GetAllItems()
        {
            var positions = repository.GetAllItems();
            return Mapper.Map<IQueryable<Position>, IQueryable<PositionModel>>(positions);
        }

        public PositionModel GetItemById(Guid id)
        {
            var position = repository.GetItemById(id);
            return Mapper.Map<Position, PositionModel>(position);
        }

        public Guid Remove(PositionModel item)
        {
            return repository.Remove(item.Id);
        }

        public Guid Update(PositionModel item)
        {
            var position = Mapper.Map<PositionModel, Position>(item);
            return repository.Update(position);
        }
    }
}
