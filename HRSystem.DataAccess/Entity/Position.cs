﻿using System;
using System.Collections.Generic;

namespace HRSystem.DataAccess.Entity
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public Position()
        {
            Id = Guid.NewGuid();
        }
    }
}
