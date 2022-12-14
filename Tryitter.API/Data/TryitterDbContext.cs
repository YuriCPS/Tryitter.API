using Microsoft.EntityFrameworkCore;
using Tryitter.API.Data.Configuration;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ModuleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TweetConfiguration());
        }
    }
}
