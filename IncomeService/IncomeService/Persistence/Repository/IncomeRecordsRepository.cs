using IncomeService.DataAccess.IRepository;
using IncomeService.Models;

namespace IncomeService.Persistence.Repository
{
    public class IncomeRecordsRepository : Repository<IncomeRecord>, IIncomeRecordsRepository
    {
        public IncomeRecordsRepository(IncomeDbContext context) : base(context)
        {
        }
    }
}
