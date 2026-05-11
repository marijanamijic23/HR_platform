using hr_team.Models;

namespace hr_team.Repository
{
    public interface ISkillService
    {
        public void AddSkill(Skill skill);
        public List<Skill> SeeAllSkills();
        public int getStatus();
    }

}
