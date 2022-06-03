using Ardalis.Specification;

namespace EoSoftware.Northwind.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
