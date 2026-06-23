using HMS.Shared.Domain;

namespace HMS.Shared.Interfaces;

public interface IRepository<T, TId> where T : AggregateRoot<TId>
{
    Task<T?> GetByIdAsync(TId id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
