using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace learn_programming_services.Database.Seeds
{
    public class PracticeLevelsSeedingData : IEntityTypeConfiguration<PracticeLevels>
    {
        public void Configure(EntityTypeBuilder<PracticeLevels> builder)
        {
            builder.HasData
                (
                    new PracticeLevels()
                    {
                        Id = 1,
                        Name = "Easy",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new PracticeLevels()
                    {
                        Id = 2,
                        Name = "Medium",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new PracticeLevels()
                    {
                        Id = 3,
                        Name = "Hard",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    }
                );
        }
    }
}
