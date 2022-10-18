using System;
using System.Collections.Generic;

namespace EoSoftware.Northwind.Domain.Entities
{
    public class Territory
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        public string TerritoryId { get; set; } = null!;
        public char TerritoryDescription { get; set; }
        public short RegionId { get; set; }

        public virtual Region Region { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
