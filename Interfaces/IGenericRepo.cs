namespace DailyEntryArchiving.Interfaces
{
    public interface IGenericRepo <T>where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T entity);
        int Update(int id,T entity);
        int Delete(int id);
    }
}

