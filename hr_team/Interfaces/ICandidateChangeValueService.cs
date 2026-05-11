using hr_team.Models;

namespace hr_team.Repository
{
    public interface ICandidateChangeValueService
    {
        public void AddJobCandidate(Candidate candidate);
        public void RemoveCandidate(int candidateId);
        public void UpdateJobCandidateWithSkills(int candidateId, string name);
        public void RemoveSkillsFromJobCandidate(int candidateId);

        public int GetStatus();

    }
}
