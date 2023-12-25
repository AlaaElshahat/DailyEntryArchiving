using DailyEntryArchiving.Entities;
using DailyEntryArchiving.Interfaces;

namespace DailyEntryArchiving.Repositories
{
    public class DailyEntryRepo : GenericRepo<DailyEntry>, IDailyEntryRepo
    {
        
        public DailyEntryRepo(NitcoContext _context) : base(_context)
        {
        }
    }
}
