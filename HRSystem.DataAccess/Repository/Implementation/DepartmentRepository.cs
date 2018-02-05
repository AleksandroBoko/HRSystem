using HRSystem.DataAccess.Entity;
using System;
using System.Linq;

namespace HRSystem.DataAccess.Repository.Implementation
{
    class DepartmentRepository : IRepository<Department>
    {
        public DepartmentRepository()
        {
            context = new HRModel();
        }

        private readonly HRModel context;

        public Guid Add(Department item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var department = context.Departments.Add(item);
            var departmentId = department.Id;
            Save();
            return departmentId;
        }

        public IQueryable<Department> GetAllItems()
        {
            return context.Departments;
        }

        public Department GetItemById(Guid id)
        {
            return context.Departments.FirstOrDefault(x => x.Id == id);
        }

        public Guid Remove(Guid id)
        {
            var department = context.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null)
            {
                throw new NullReferenceException("The department wasn't found");
            }

            var removedDepartment = context.Departments.Remove(department);
            if (removedDepartment == null)
            {
                throw new NullReferenceException("The department wasn't removed");
            }
            Save();
            return removedDepartment.Id;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Guid Update(Department item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var department = context.Departments.FirstOrDefault(x => x.Id == item.Id);
            if (department == null)
            {
                throw new NullReferenceException("The department wasn't found");
            }

            department.Name = item.Name;
            Save();
            return item.Id;
        }
    }
}
