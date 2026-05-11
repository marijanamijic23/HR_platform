using hr_team.Configuration;
using hr_team.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_team.Data
{
    public class HrContext : DbContext
    {
        public HrContext(DbContextOptions<HrContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateSkillConfiguration());
        }
        public DbSet<Candidate> Candidates { get; set; } = default!;
        public DbSet<Skill> Skills { get; set; } = default!;
        public DbSet<CandidateSkill> CandidateSkills { get; set; } = default!;
    }
}
