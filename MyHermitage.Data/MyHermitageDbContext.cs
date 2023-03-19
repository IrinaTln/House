using Microsoft.EntityFrameworkCore;
using MyHermitage.Core.Domain;

namespace MyHermitage.Data
{
    public class MyHermitageDbContext : DbContext
    {
        public MyHermitageDbContext(DbContextOptions<MyHermitageDbContext> options) : base(options) { }

        public DbSet<House> House { get; set; }
    }
}