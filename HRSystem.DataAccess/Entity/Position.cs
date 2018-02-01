using System;
using System.Linq;

namespace HRSystem.DataAccess.Entity
{
    public class Position
    {
        public Guid Id { get; set; }
        public string name { get; set; }

        public virtual IQueryable<Employee> Employees { get; set; }
    }
}
