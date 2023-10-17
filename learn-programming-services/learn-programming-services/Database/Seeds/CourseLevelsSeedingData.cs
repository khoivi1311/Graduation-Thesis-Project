using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace learn_programming_services.Database.Seeds
{
    public class CourseLevelsSeedingData : IEntityTypeConfiguration<CourseLevels>
    {
        public void Configure(EntityTypeBuilder<CourseLevels> builder)
        {
            builder.HasData
                (
                    new CourseLevels()
                    {
                        Id = 1,
                        Name = "Basic knowledge",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    },
                    new CourseLevels()
                    {
                        Id = 2,
                        Name = "General knowledge",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    },
                    new CourseLevels()
                    {
                        Id = 3,
                        Name = "Specialized knowledge",
                        CreateDate = DateTime.Parse("2023-04-04 11:20:05.000000"),
                        UpdateDate = DateTime.Parse("2023-04-04 11:20:05.000000")
                    }
                );
        }
    }
}
