using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tryitter.API.Data.Configuration
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasData(
                new Module
                {
                    Id = 1,
                    Name = "Fundamentos",
                },
                new Module
                {
                    Id = 2,
                    Name = "Front-end",
                },
                new Module
                {
                    Id = 3,
                    Name = "Back-end",
                },
                new Module
                {
                    Id = 4,
                    Name = "Ciencia da Computação",
                },
                new Module
                {
                    Id = 5,
                    Name = "Beyond",
                });
        }
    }
}
              