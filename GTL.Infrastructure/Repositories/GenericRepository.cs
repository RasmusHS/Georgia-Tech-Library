using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GTL.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;

        private DbSet<T> table = null;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            //Whatever class name we specify while creating the instance of GenericRepository
            //That class name will be stored in the table variable
            table = _context.Set<T>();
        }

        public async Task<T> InsertAsync(T obj)
        {
            //It will mark the Entity state as Added State
            table.Add(obj);
            return Result.Ok<T>(obj);
        }

        public async Task<IEnumerable<T>> InsertRangeAsync(List<T> obj)
        {
            await table.AddRangeAsync(obj);
            return Result<IEnumerable<T>>.Ok<T>(obj).Value;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T> GetByIdAsync(object[] id)
        {
            return await table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return table.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<T, bool> value)
        {
            return table.Where<T>(value).ToList();
        }

        public async Task<T> UpdateAsync(T obj)
        {
            //First attach the object to the table
            table.Attach(obj);
            //Then set the state of the Entity as Modified
            _context.Entry(obj).State = EntityState.Modified;
            return Result.Ok<T>(obj);
        }

        public void Delete(object id)
        {
            //First, fetch the record from the table
            T existing = table.Find(id);
            //This will mark the Entity State as Deleted
            table.Remove(existing);
        }

        public void Delete(object[] id)
        {
            //First, fetch the record from the table
            T existing = table.Find(id);
            //This will mark the Entity State as Deleted
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
