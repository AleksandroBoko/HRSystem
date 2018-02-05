using HRSystem.DataAccess.Entity;
using System;
using System.Linq;

namespace HRSystem.DataAccess.Repository.Implementation
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public EmployeeRepository()
        {
            context = new HRModel();
        }

        private readonly HRModel context;

        public Guid Add(Employee item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var employee = context.Employees.Add(item);
            var employeeId = employee.Id;
            Save();
            return employeeId;
        }

        public IQueryable<Employee> GetAllItems()
        {
            return context.Employees;
        }

        public Employee GetItemById(Guid id)
        {
            return context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public Guid Remove(Guid id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                throw new NullReferenceException("The employee wasn't found");
            }

            var removedEmployee = context.Employees.Remove(employee);
            if (removedEmployee == null)
            {
                throw new NullReferenceException("The employee wasn't removed");
            }
            Save();
            return removedEmployee.Id;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Guid Update(Employee item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            var employee = context.Employees.FirstOrDefault(x => x.Id == item.Id);
            if (employee == null)
            {
                throw new NullReferenceException("The employee wasn't found");
            }

            employee.FirstName = item.FirstName;
            employee.SecondName = item.SecondName;
            employee.LastName = item.LastName;
            employee.Code = item.Code;
            employee.DateBorn = item.DateBorn;
            employee.DepartmentId = item.DepartmentId;
            employee.SpecializationId = item.SpecializationId;
            employee.PositionId = item.PositionId;
            employee.Image = employee.Image;
            employee.Technologies = employee.Technologies;

            Save();
            return item.Id;
        }
    }
}
