using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Services.Context
{
    public class MVCContext: DbContext
    {
        public MVCContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Customers> customers { get; set; }
    }
}
