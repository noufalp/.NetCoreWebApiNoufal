using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
namespace WebApp.Models
{
    public class Repository <T> :IRepository <T> where T : Product
    {
        //The following variable is going to hold the InvoiceContext instance
        private InvoiceContext _context = null;
        //The following Variable is going to hold the DbSet Entity
        private DbSet<T> table = null;
        public Repository(InvoiceContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }
        public async Task<T> GetAsync(long id)
        {
            return await table.FindAsync(id);
        }
        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            table.Update(entity);
            await _context.SaveChangesAsync();            
        }
        public async Task DeleteAsync(Int64 id)
        {
            var entity = await table.FindAsync(id);
            if (entity != null)
            {
                table.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
