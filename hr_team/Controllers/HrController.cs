using hr_team.Models;
using hr_team.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hr_team.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrController : ControllerBase
    {
        ICandidateService _candidateService;
        ISkillService _skillService;
        public HrController(ICandidateService candidateService, ISkillService skill)
        {
            _candidateService = candidateService;
            _skillService = skill;
        }

        [HttpPost]
        [Route("AddCandidate")]
        public void AddJobCandidate(Candidate candidate)
        {
            _candidateService.AddJobCandidate(candidate);
        }

        [HttpPost]
        [Route("RemoveCandidate")]
        public void RemoveCandidate(int candidateId)
        {
            _candidateService.RemoveCandidate(candidateId);
        }

        [HttpGet]
        [Route("SearchCandidatesByName")]
        public List<Candidate> SearchCandidatesByName(string name)
        {
            return _candidateService.SearchCandidatesByName(name);
        }

        [HttpGet]
        [Route("SearchCandidateByGivenSkill")]
        public List<Candidate> SearchCandidateByGivenSkill(string skill)
        {
            return _candidateService.SearchCandidateByGivenSkill(skill);
        }

        [HttpPost]
        [Route("UpdateJobCandidateWithSkills")]
        public void UpdateJobCandidateWithSkills(int candidateId, Skill skill)
        {
            _candidateService.UpdateJobCandidateWithSkills(candidateId, skill);
        }

        [HttpPost]
        [Route("RemoveSkillsFromJobCandidate")]
        public void RemoveSkillsFromJobCandidate(int candidateId, Skill skill)
        {
            _candidateService.RemoveSkillsFromJobCandidate(candidateId, skill);
        }

        [HttpPost]
        [Route("AddSkill")]
        public void AddSkill(Skill skill)
        {
            _skillService.Add_skill(skill);
        }
    }
}
