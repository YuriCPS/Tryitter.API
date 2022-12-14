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
                    UserName = "Admin",
                    Password = "admin123",
                    Email = "admin@email.com.br",
                    FirstName = "Admin",
                    LastName = "Tryitter",
                    Bio = "Administrador do Tryitter",
                    ModuleId = 5,
                },
                new User
                {
                    Id = 2,
                    UserName = "Yuri",
                    Password = "yuri123",
                    Email = "yuri@email.com.br",
                    FirstName = "Yuri",
                    LastName = "Carvalho",
                    Bio = "Criador do Tryitter",
                    ModuleId = 5,
                });
        }
    }
}





