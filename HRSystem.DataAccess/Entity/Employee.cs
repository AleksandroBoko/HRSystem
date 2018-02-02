using System;
using System.Collections.Generic;

namespace HRSystem.DataAccess.Entity
{
    public class Employee
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBorn { get; set; }
        public string Image { get; set; }

        public Guid DepartmentId { get; set; }
        public virtual Department EmpDepartment { get; set; }

        public Guid PositionId { get; set; }
        public virtual Position EmpPosition { get; set; }

        public Guid SpecializationId { get; set; }
        public virtual Specialization EmpSpecialization { get; set; }

        public virtual ICollection<Technology> Technologies{ get; set; }
    }
}
