using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace learn_programming_services.Database.Seeds
{
    public class ContestStatusesSeedingData : IEntityTypeConfiguration<ContestStatuses>
    {
        public void Configure(EntityTypeBuilder<ContestStatuses> builder)
        {
            builder.HasData
                (
                    new ContestStatuses()
                    {
                        Id = 1,
                        Name = "Comming soon",
                        Description = "The new contest will come into next days",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new ContestStatuses()
                    {
                        Id = 2,
                        Name = "Open registration",
                        Description = "The contest open registration for participants",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new ContestStatuses()
                    {
                        Id = 3,
                        Name = "Closed registration",
                        Description = "The contest will close registration one day before the start date",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new ContestStatuses()
                    {
                        Id = 4,
                        Name = "On going",
                        Description = "The contest is on going",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new ContestStatuses()
                    {
                        Id = 5,
                        Name = "Finished",
                        Description = "The contest had finished",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    }
                );
        }
    }
}
