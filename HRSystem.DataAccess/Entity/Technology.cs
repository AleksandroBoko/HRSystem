using System;
using System.Linq;

namespace HRSystem.DataAccess.Entity
{
    public class Technology
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IQueryable<Employee> Employess { get; set; }
    }
}
