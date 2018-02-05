using HRSystem.DataAccess.Entity;
using System;
using System.Linq;

namespace HRSystem.DataAccess.Repository.Implementation
{
    class SpecializationRepository : IRepository<Specialization>
    {
        public SpecializationRepository()
        {
            context = new HRModel();
        }

        private readonly HRModel context;

        public Guid Add(Specialization item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var specialization = context.Specializations.Add(item);
            var specializationId = specialization.Id;
            Save();
            return specializationId;
        }

        public IQueryable<Specialization> GetAllItems()
        {
            return context.Specializations;
        }

        public Specialization GetItemById(Guid id)
        {
            return context.Specializations.FirstOrDefault(x => x.Id == id);
        }

        public Guid Remove(Guid id)
        {
            var specialization = context.Specializations.FirstOrDefault(x => x.Id == id);
            if(specialization == null)
            {
                throw new NullReferenceException("The specialization wasn't found");
            }

            var removedSpecialization = context.Specializations.Remove(specialization);
            if (removedSpecialization == null)
            {
                throw new NullReferenceException("The specialization wasn't removed");
            }
            Save();
            return removedSpecialization.Id;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Guid Update(Specialization item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var specialization = context.Specializations.FirstOrDefault(x => x.Id == item.Id);
            if (specialization == null)
            {
                throw new NullReferenceException("The specialization wasn't found");
            }

            specialization.Name = item.Name;
            Save();
            return item.Id;
        }
    }
}
