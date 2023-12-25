using DailyEntryArchiving.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DailyEntryArchiving.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        readonly NitcoContext context;
        public GenericRepo(NitcoContext _context)
        {
            context = _context;
        }
        public int Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
           T? entity= context.Set<T>().Find(id);
            if(entity != null) {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
                return context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            T?entity= context.Set<T>().Find(id);
            return entity;

        }

        public int Update(int id, T entity)
        {
            T? existingEntity = context.Set<T>().Find(id);
            if (existingEntity == null)
            {
                return 0;
            }
            context.Entry(existingEntity).CurrentValues.SetValues(entity);
            context.SaveChanges();
            return context.SaveChanges();
        }
    }
}
