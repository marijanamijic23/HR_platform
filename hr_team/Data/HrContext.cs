using hr_team.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_team.Data
{
    public class HrContext : DbContext
    {
        public HrContext(DbContextOptions<HrContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; } = default!;
        public DbSet<Skill> Skills { get; set; } = default!;
        public DbSet<CandidateSkill> CandidateSkills { get; set; } = default!;
    }
}
