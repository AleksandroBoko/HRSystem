using System;
using System.Linq;

namespace HRSystem.DataAccess.Entity
{
    public class Specialization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual IQueryable<Employee> Employess { get; set; }
    }
}
