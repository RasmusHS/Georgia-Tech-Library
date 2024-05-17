namespace GTL.Application.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        void Delete(object id);
        void Save();
    }
}
