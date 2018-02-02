using HRSystem.DataAccess.Entity;
using System;
using System.Linq;

namespace HRSystem.DataAccess.Repository.Implementation
{
    public class PositionRepository : IRepository<Position>
    {
        public PositionRepository()
        {
            context = new HRModel();
        }

        private readonly HRModel context;

        public Guid Add(Position item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var position = context.Positions.Add(item);
            var positionId = position.Id;
            Save();
            return positionId;
        }

        public IQueryable<Position> GetAllItems()
        {
            return context.Positions;
        }

        public Position GetItemById(Guid id)
        {
            return context.Positions.FirstOrDefault(x => x.Id == id);
        }

        public Guid Remove(Guid id)
        {
            var position = context.Positions.FirstOrDefault(x => x.Id == id);
            if (position == null)
            {
                throw new NullReferenceException("The position wasn't found");
            }

            context.Positions.Remove(position);
            Save();
            return id;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Guid Update(Position item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var position = context.Positions.FirstOrDefault(x => x.Id == item.Id);
            if (position == null)
            {
                throw new NullReferenceException("The position wasn't found");
            }

            position.Name = item.Name;
            Save();
            return item.Id;
        }
    }
}
