using hr_team.Data;
using hr_team.Models;
using hr_team.Repository;

namespace hr_team.Services
{
    public class SkillService : ISkillService
    {
        HrContext _context;
        public static int status = 0;

        public SkillService(HrContext context)
        {
            _context = context;
        }

        public void AddSkill(Skill skill)
        {
           status = 0;
            var skill_name = _context.Skills.Where(s => s.name == skill.name).FirstOrDefault();
            if(skill_name != null)
            {
                status = 1;
                return;
            }
            _context.Add(skill);
           _context.SaveChanges();
        }

        public List<Skill> SeeAllSkills()
        {
            status = 0;
            var list = _context.Skills.ToList();
            return list;
        }

        public int getStatus()
        {
            return status;
        }
    }
}