using DailyEntryArchiving.Entities;

namespace DailyEntryArchiving.Interfaces
{
    public interface IDailyDetailsEntryRepo:IGenericRepo<DailyDetailsEntry>
    {
        List<DailyDetailsEntry> GetDetailedByEntryID(int id);
    }
}
