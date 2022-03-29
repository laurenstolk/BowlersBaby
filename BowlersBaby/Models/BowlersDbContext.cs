using System;
using Microsoft.EntityFrameworkCore;

namespace BowlersBaby.Models
{
    public class BowlersDbContext : DbContext
    {
        public BowlersDbContext(DbContextOptions<BowlersDbContext> options) : base (options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; }


    }
}
