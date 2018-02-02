using System;
using System.Collections.Generic;

namespace HRSystem.DataAccess.Entity
{
    public class Specialization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employess { get; set; }
    }
}
