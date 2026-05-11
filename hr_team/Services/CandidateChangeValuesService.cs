using hr_team.Data;
using hr_team.Models;
using hr_team.Repository;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace hr_team.Services
{
    public class CandidateChangeValuesService : ICandidateChangeValueService
    {
        HrContext _context;
        public static int status = 0;
        public CandidateChangeValuesService(HrContext context)
        {
            _context = context;
        }

        public void AddJobCandidate(Candidate candidate)
        {
            status = 0;
            var existingCandidate = _context.Candidates.Where(c => c.email == candidate.email).FirstOrDefault();
            if(existingCandidate != null)
            {
                status = 1;
                return;
            }
            _context.Add(candidate);
            _context.SaveChanges();
        }

        public void RemoveCandidate(int candidateId)
        {
            status = 0;
            var candidate = _context.Candidates.Where(c => c.id == candidateId).FirstOrDefault();
            if (candidate == null)
            {
                status = 1;
                return;
            }
            _context.Candidates.Remove(candidate);
            _context.SaveChanges();
        }

        public void UpdateJobCandidateWithSkills(int candidateId, string name)
        {
            status = 0;
            var candidate = _context.Candidates.Find(candidateId);
            var skill = _context.Skills.Where(s => s.name == name).FirstOrDefault();
            var candidate_id = _context.CandidateSkills.Where(cs => cs.CandidateId == candidateId && cs.SkillId == skill.id).FirstOrDefault();
            var skill_id = _context.CandidateSkills.Where(cs => cs.CandidateId == candidateId && cs.SkillId == skill.id).FirstOrDefault();

            if (candidate == null || skill == null)
            {
                status = 1;
                return;
            }

            if (candidate_id != null && skill_id != null)
            {
                status = 2;
                return;
            }

            _context.Candidates.Join(_context.CandidateSkills, c => c.id, cs => cs.CandidateId, (c, cs) => new { Candidate = c, CandidateSkill = cs })
                .Where(joined => joined.Candidate.id == candidateId)
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
            status = 0;
            var element = _context.CandidateSkills.Where(cs => cs.CandidateId == candidateId).ToList();
            if (element == null)
            {
                status = 1;
                return;
            }
            _context.CandidateSkills.RemoveRange(element);
            _context.SaveChanges();
        }

        public int GetStatus()
        {
            return status;
        }
    }

}
