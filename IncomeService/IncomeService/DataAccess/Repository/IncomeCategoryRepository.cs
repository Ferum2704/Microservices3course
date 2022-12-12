using IncomeService.DataAccess.IRepository;
using IncomeService.Models;

namespace IncomeService.DataAccess.Repository
{
    public class IncomeCategoryRepository : Repository<IncomeCategory>, IIncomeCategoryRepository
    {
        public IncomeCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
