using DailyEntryArchiving.Entities;
using DailyEntryArchiving.Interfaces;

namespace DailyEntryArchiving.Repositories
{
    public class DailyDetailedEntryRepo : GenericRepo<DailyDetailsEntry>,IDailyDetailsEntryRepo
    {
        private readonly NitcoContext _context;
        public DailyDetailedEntryRepo(NitcoContext _context) : base(_context)
        {
        }

        public List< DailyDetailsEntry> GetDetailedByEntryID(int id)
        {
               return  _context.DailyDetailsEntries.Where(d => d.DailyEntryId == id).ToList();
        }
    }
}
