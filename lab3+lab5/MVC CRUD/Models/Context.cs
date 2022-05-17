using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }
}
