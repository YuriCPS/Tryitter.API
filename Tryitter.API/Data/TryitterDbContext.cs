using Microsoft.EntityFrameworkCore;

namespace Tryitter.API.Data
{
    public class TryitterDbContext : DbContext
    {
        public TryitterDbContext(DbContextOptions<TryitterDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Tweet> Tweets { get; set; }       
    }
}
