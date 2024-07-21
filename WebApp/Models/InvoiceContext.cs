using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Models
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
        : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
