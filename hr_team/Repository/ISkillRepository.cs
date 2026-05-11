using hr_team.Models;

namespace hr_team.Repository
{
    public interface ISkillRepository
    {
        public void Add_skill(Skill skill);
        public List<Skill> SeeAllSkills();
        public int getStatus();
    }

}
