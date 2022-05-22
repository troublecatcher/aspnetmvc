using System;
using Microsoft.EntityFrameworkCore;

namespace rsvp.Models
{
	public class Context : DbContext
	{
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Guest>? guest { get; set; }
    }
}

