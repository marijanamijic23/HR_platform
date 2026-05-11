using hr_team.Data;
using hr_team.Models;
using hr_team.Repository;

namespace hr_team.Services
{
    public class SkillService : ISkillService
    {
        HrContext _context;

        public SkillService(HrContext context)
        {
            _context = context;
        }

        public void Add_skill(Skill skill)
        {
           _context.Add(skill);
           _context.SaveChanges();
        }

        public List<Skill> SeeAllSkills()
        {
            var list = _context.Skills.ToList();
            return list;
        }
    }
}