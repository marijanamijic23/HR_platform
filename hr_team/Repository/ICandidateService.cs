using hr_team.Models;

namespace hr_team.Repository
{
    public interface ICandidateService
    {
      public void AddJobCandidate(Candidate candidate);
      public void RemoveCandidate(int candidateId);
      public List<Candidate> SearchCandidatesByName(string name);
      public List<Candidate> SearchCandidateByGivenSkill(string skill);
      public void UpdateJobCandidateWithSkills(int candidateId, Skill skill);
      public void RemoveSkillsFromJobCandidate(int candidateId, Skill skill);
    }
}
