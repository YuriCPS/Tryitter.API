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
                },
                new Tweet
                {
                    Id = 3,
                    Content = "Este é meu segundo tweet",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = 2,
                },
                new Tweet
                {
                    Id = 4,
                    Content = "Seja bem vindo ao Tryitter",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = 1,
                },
                new Tweet
                {
                    Id = 5,
                    Content = "Este é o meu último tweet",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = 2,
                });
        }
    }
}
