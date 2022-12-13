using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tryitter.API.Data.Configuration
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.HasData(
                new Tweet
                {
                    Id = 1,
                    Content = "Esté é o primeiro tweet do Tryitter",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = 2,                    
                },
                new Tweet
                {
                    Id = 2,
                    Content = "Olá, mundo!",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = 1,
                });
        }
    }
}
