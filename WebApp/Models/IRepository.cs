using System.Collections.Generic;
namespace WebApp.Models
{
    public interface IRepository<T> where T : Product
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Int64 id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Int64 id);
    }
}
