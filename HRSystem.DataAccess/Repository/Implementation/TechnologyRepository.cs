using HRSystem.DataAccess.Entity;
using System;
using System.Linq;

namespace HRSystem.DataAccess.Repository.Implementation
{
    class TechnologyRepository : IRepository<Technology>
    {
        public TechnologyRepository()
        {
            context = new HRModel();
        }

        private readonly HRModel context;

        public Guid Add(Technology item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var technnology = context.Technologies.Add(item);
            var technnologytId = technnology.Id;
            Save();
            return technnologytId;
        }

        public IQueryable<Technology> GetAllItems()
        {
            return context.Technologies;
        }

        public Technology GetItemById(Guid id)
        {
            return context.Technologies.FirstOrDefault(x => x.Id == id);
        }

        public Guid Remove(Guid id)
        {
            var technology = context.Technologies.FirstOrDefault(x => x.Id == id);
            if (technology == null)
            {
                throw new NullReferenceException("The technology wasn't found");
            }

            var removedTechnology = context.Technologies.Remove(technology);
            if (removedTechnology == null)
            {
                throw new NullReferenceException("The technology wasn't removed");
            }
            Save();
            return removedTechnology.Id;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Guid Update(Technology item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var technology = context.Technologies.FirstOrDefault(x => x.Id == item.Id);
            if (technology == null)
            {
                throw new NullReferenceException("The technology wasn't found");
            }

            technology.Name = item.Name;
            technology.Description = item.Description;
            Save();
            return item.Id;
        }
    }
}
