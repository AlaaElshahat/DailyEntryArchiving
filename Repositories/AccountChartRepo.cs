using DailyEntryArchiving.Entities;
using DailyEntryArchiving.Interfaces;

namespace DailyEntryArchiving.Repositories
{
    public class AccountChartRepo : GenericRepo<AccountChart>,IAccountChartRepo
    {
        public AccountChartRepo(NitcoContext _context) : base(_context)
        {
        }
    }
}
