using hr_team.Data;
using hr_team.Models;

namespace hr_team.Services
{
    public class SkillService
    {
        HrContext _context;

        public SkillService(HrContext context)
        {
            _context = context;
        }

        public void Add_skill(Skill skill)
        {
           throw new NotImplementedException();
        }


    }
}