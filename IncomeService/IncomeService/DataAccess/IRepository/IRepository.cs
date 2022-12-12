using System.Linq.Expressions;

namespace IncomeService.DataAccess.IRepository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(Expression<Func<T, bool>> filter);
    }
}
