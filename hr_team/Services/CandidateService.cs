using hr_team.Data;
using hr_team.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace hr_team.Services
{
    public class CandidateService
    {
        HrContext _context;

        public CandidateService(HrContext context)
        {
            _context = context;
        }

        public async Task AddJobCandidate(Candidate candidate)
        {
           throw new NotImplementedException();
        }

        public void RemoveCandidate(int candidateId)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> SearchCandidatesByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> SearchCandidateByGivenSkill(string skill)
        {
            throw new NotImplementedException();
        }

        public void UpdateJobCandidateWithSkills(int candidateId, Skill skill)
        {
           throw new NotImplementedException();
        }

        public void RemoveSkillsFromJobCandidate(int candidateId, Skill skill)
        {
           throw new NotImplementedException();

        }
    }
}
