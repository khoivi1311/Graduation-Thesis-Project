using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace learn_programming_services.Database.Seeds
{
    public class PermissionsSeedingData : IEntityTypeConfiguration<Permissions>
    {
        public void Configure(EntityTypeBuilder<Permissions> builder)
        {
            builder.HasData
                (
                    new Permissions()
                    {
                        Id = 1,
                        Name = "USER MANAGEMENT",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    },
                    new Permissions()
                    {
                        Id = 2,
                        Name = "POST COURSE",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    },
                    new Permissions()
                    {
                        Id = 3,
                        Name = "CREATE EXAMINATION",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    },
                    new Permissions()
                    {
                        Id = 4,
                        Name = "POST PRACTICE",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    },
                    new Permissions()
                    {
                        Id = 5,
                        Name = "LEARNING",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    },
                    new Permissions()
                    {
                        Id = 6,
                        Name = "TAKE EXAMINATION",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    }
                );
        }
    }
}
