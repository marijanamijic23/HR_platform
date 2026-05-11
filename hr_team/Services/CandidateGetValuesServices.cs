using hr_team.Data;
using hr_team.Models;
using hr_team.Repository;

namespace hr_team.Services
{
    public class CandidateGetValuesServices : ICandidateGetValuesRepository
    {
        HrContext _context;
        public static int status = 0;
        public CandidateGetValuesServices(HrContext context)
        {
            _context = context;
        }

        public List<Candidate> SearchCandidatesByName(string name)
        {
            status = 0;
            var list = _context.Candidates.Where(c => c.full_name == name).ToList();
            if(list.Count == 0)
            {
                status = 1;
                return new List<Candidate>();
            }
            return list;
        }

        public List<Candidate> SearchCandidateByGivenSkill(string skill)
        {
            status = 0;
            var skill_id = _context.Skills.Where(s => s.name == skill).Select(s => s.id).FirstOrDefault();
            if(skill_id == 0)
            {
                status = 1;
                return new List<Candidate>();
            }
            var candidate_id = _context.CandidateSkills.Where(cs => cs.SkillId == skill_id).Select(cs => cs.CandidateId).ToList();
            var candidates = _context.Candidates.Where(c => candidate_id.Contains(c.id)).ToList();
            return candidates;
        }

        public List<Candidate> GetAllCandidates()
        {
            status = 0;
            var candidates = _context.Candidates.ToList();
            return candidates;
        }

        public int getStatus()
        {
            return status;
        }
    }
}
