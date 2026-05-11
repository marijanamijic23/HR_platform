using hr_team.Data;
using hr_team.Models;
using hr_team.Repository;
using Microsoft.EntityFrameworkCore;

namespace hr_team.Services
{
    public class CandidateSkillService : ICandidateSkillRepository
    {
        HrContext _context;
        public CandidateSkillService(HrContext context)
        {
            _context = context;
        }

        public List<CandidateSkill> ShowAllElements()
        {
            return _context.CandidateSkills.Include(c => c.Skill).Include(c => c.Candidate).ToList();
        }
    }
}
