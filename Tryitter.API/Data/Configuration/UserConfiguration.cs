using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tryitter.API.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "admin123",
                    Email = "admin@email.com.br",
                    FirstName = "Admin",
                    LastName = "Tryitter",
                    Bio = "Administrador do Tryitter",
                    ImageUrl = "https://via.placeholder.com/300/09f/fff.jpg",
                    ModuleId = 5,
                },
                new User
                {
                    Id = 2,
                    UserName = "yuri",
                    Password = "yuri123",
                    Email = "yuri@email.com.br",
                    FirstName = "Yuri",
                    LastName = "Carvalho",
                    Bio = "Criador do Tryitter",
                    ImageUrl = "https://via.placeholder.com/300/09f/fff.jpg",
                    ModuleId = 5,
                });
        }
    }
}





