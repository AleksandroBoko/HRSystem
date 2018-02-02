using System;
using System.Collections.Generic;

namespace HRSystem.DataAccess.Entity
{
    public class Technology
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
