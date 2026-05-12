using hr_team.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hr_team.Configuration
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skill");

            builder.HasData(
                new Skill
                {
                    id = 1,
                    name = "Java",
                },
                new Skill
                {
                    id = 2,
                    name = "ASP.NET Core"
                },
                new Skill
                {
                    id = 3,
                    name = "Entity Framework Core"
                }
            );
        }
    }
}
