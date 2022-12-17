using IncomeService.DataAccess.IRepository;
using IncomeService.Models;

namespace IncomeService.Persistence.Repository
{
    public class IncomeCategoryRepository : Repository<IncomeCategory>, IIncomeCategoryRepository
    {
        public IncomeCategoryRepository(IncomeDbContext context) : base(context)
        {
        }
    }
}
