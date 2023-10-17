using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace learn_programming_services.Database.Seeds
{
    public class RolesSeedingData : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasData
                (
                    new Roles()
                    {
                        Id = 1,
                        Name = "ADMIN",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    },
                    new Roles()
                    {
                        Id = 2,
                        Name = "AUTHOR",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    },
                    new Roles()
                    {
                        Id = 3,
                        Name = "STUDENT",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    }
                );
        }
    }
}
