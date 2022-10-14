using EoSoftware.Northwind.Core.Interfaces;

namespace EoSoftware.Northwind.Core.Entities;

public class Region : BaseEntity, IAggregateRoot
{
    public string Description { get; set; }
}
