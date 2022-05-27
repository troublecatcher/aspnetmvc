using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Orders>? Orders { get; set; }
        public DbSet<Item>? Items { get; set; }
        public DbSet<OrdersInfo>? OrdersInfo { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
