using System;
using System.Collections.Generic;

namespace EoSoftware.Northwind.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public short CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
