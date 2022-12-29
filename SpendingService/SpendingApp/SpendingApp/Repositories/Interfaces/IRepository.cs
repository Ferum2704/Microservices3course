using System.Linq.Expressions;

namespace SpendingApp.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id, CancellationToken ct);
    Task<List<T>> GetAllAsync(CancellationToken ct);
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    Task<T> AddAsync(T entity, CancellationToken ct);
    void Remove(T entity);
    T Update(T entity);
}