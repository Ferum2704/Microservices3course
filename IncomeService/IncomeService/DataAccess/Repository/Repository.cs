using IncomeService.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IncomeService.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            dbSet.Remove(GetFirstOrDefault(filter));
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            return query.Where(filter).FirstOrDefault();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
