using hr_team.Data;
using hr_team.Models;
using hr_team.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace hr_team.Services
{
    public class CandidateService : ICandidateService
    {
        HrContext _context;

        public CandidateService(HrContext context)
        {
            _context = context;
        }

        public void AddJobCandidate(Candidate candidate)
        {
          _context.Add(candidate);
          _context.SaveChanges();
        }

        public void RemoveCandidate(int candidateId)
        {
            var candidate = _context.Candidates.Find(candidateId);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                _context.SaveChanges();
            }
        }

        public List<Candidate> SearchCandidatesByName(string name)
        {
            var list = _context.Candidates.Where(c => c.full_name.Contains(name)).ToList();
            return list;
        }

        public List<Candidate> SearchCandidateByGivenSkill(string skill)
        {
            var skill_id = _context.Skills.Where(s => s.name == skill).Select(s => s.id).FirstOrDefault();
            var candidate_id = _context.CandidateSkills.Where(cs => cs.CandidateId == skill_id).Select(cs => cs.CandidateId).ToList();
            var candidates = _context.Candidates.Where(c => candidate_id.Contains(c.Id)).ToList();
            return candidates;
        }

        public void UpdateJobCandidateWithSkills(int candidateId,string name)
        {
            _context.Candidates.Join(_context.CandidateSkills, c => c.Id, cs => cs.CandidateId, (c, cs) => new { Candidate = c, CandidateSkill = cs })
                .Where(joined => joined.Candidate.Id == candidateId)
                .ToList()
                .ForEach(joined =>
                {
                    _context.Skills.Where(s => s.id == joined.CandidateSkill.SkillId).ToList().ForEach(skill =>
                    {
                        skill.name = name;
                    });
                });
                _context.CandidateSkills.Add(new CandidateSkill { CandidateId = candidateId, SkillId = _context.Skills.Where(s => s.name == name).Select(s => s.id).FirstOrDefault() });
                _context.SaveChanges();

        }

        public void RemoveSkillsFromJobCandidate(int candidateId)
        {
            var еlement = _context.CandidateSkills.Where(cs => cs.CandidateId == candidateId).ToList();
            if (еlement != null)
            {
                _context.CandidateSkills.RemoveRange(еlement);
                _context.SaveChanges();
            }
        }

        public List<Candidate> GetAllCandidates()
        {
            var candidates = _context.Candidates.ToList();
            return candidates;
        }
    }
}
