using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SpendingApp.Persistence;
using SpendingApp.Repositories.Interfaces;

namespace SpendingApp.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly SpendingContext Context;

    public Repository(SpendingContext context)
    {
        Context = context;
    }

    public async Task<List<T>> GetAllAsync(CancellationToken ct)
    {
        return await Context.Set<T>().ToListAsync(ct);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await Context.Set<T>().FindAsync(new object?[] { id }, ct);
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<T> AddAsync(T entity, CancellationToken ct)
    {
        return (await Context.Set<T>().AddAsync(entity, ct)).Entity;
    }

    public void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
    }

    public T Update(T entity)
    {
        return Context.Set<T>().Update(entity).Entity;
    }
}