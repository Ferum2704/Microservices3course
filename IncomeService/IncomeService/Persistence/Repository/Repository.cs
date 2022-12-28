using IncomeService.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IncomeService.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IncomeDbContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(IncomeDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public T Add(T entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            DbSet.Remove(GetFirstOrDefault(filter));
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;
            return query.Where(filter).FirstOrDefault();
        }

        public T Update(T entity)
        {
            return DbSet.Update(entity).Entity;
        }
    }
}