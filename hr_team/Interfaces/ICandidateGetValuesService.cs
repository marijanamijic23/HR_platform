using hr_team.Models;

namespace hr_team.Repository
{
    public interface ICandidateGetValuesService
    {
        public List<Candidate> SearchCandidatesByName(string name);
        public List<Candidate> SearchCandidateByGivenSkill(string skill);
        public List<Candidate> GetAllCandidates();
        public int getStatus();

    }
}
