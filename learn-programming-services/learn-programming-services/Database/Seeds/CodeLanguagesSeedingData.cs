using learn_programming_services.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace learn_programming_services.Database.Seeds
{
    public class CodeLanguagesSeedingData : IEntityTypeConfiguration<CodeLanguages>
    {
        public void Configure(EntityTypeBuilder<CodeLanguages> builder)
        {
            builder.HasData
                (
                    new CodeLanguages()
                    {
                        Id = 1,
                        Name = "C",
                        Version = "11.3.0",
                        SubmitName = "c",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new CodeLanguages()
                    {
                        Id = 2,
                        Name = "C++",
                        Version = "11.3.0",
                        SubmitName = "cpp",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new CodeLanguages()
                    {
                        Id = 3,
                        Name = "Java",
                        Version = "11.0.19",
                        SubmitName = "java",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new CodeLanguages()
                    {
                        Id = 4,
                        Name = "NodeJS",
                        Version = "12.22.9",
                        SubmitName = "nodejs",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new CodeLanguages()
                    {
                        Id = 5,
                        Name = "Octave",
                        Version = "6.4.0",
                        SubmitName = "octave",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new CodeLanguages()
                    {
                        Id = 6,
                        Name = "Pascal",
                        Version = "3.2.2",
                        SubmitName = "pascal",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new CodeLanguages()
                    {
                        Id = 7,
                        Name = "PHP",
                        Version = "8.1.2",
                        SubmitName = "php",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    },
                    new CodeLanguages()
                    {
                        Id = 8,
                        Name = "Python 3",
                        Version = "3.10.6",
                        SubmitName = "python3",
                        CreateDate = DateTime.Parse("2023-05-22 06:50:15.143869"),
                        UpdateDate = DateTime.Parse("2023-05-22 06:50:15.143869")
                    }
                );
        }
    }
}
