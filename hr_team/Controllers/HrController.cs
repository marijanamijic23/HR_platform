using hr_team.Models;
using hr_team.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net;

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
        public void UpdateJobCandidateWithSkills(int skillId,string name)
        {
            _candidateService.UpdateJobCandidateWithSkills(skillId,name);
        }

        [HttpPost]
        [Route("RemoveSkillsFromJobCandidate")]
        public void RemoveSkillsFromJobCandidate(int candidateId)
        {
            _candidateService.RemoveSkillsFromJobCandidate(candidateId);
        }

        [HttpPost]
        [Route("AddSkill")]
        public void AddSkill(Skill skill)
        {
            _skillService.Add_skill(skill);
        }

        [HttpGet]
        [Route("SeeAllSkills")]
        public List<Skill> SeeAllSkills()
        {
            return _skillService.SeeAllSkills();
        }

        [HttpGet]
        [Route("GetAllCandidates")]
        public List<Candidate> GetAllCandidates()
        {
            return _candidateService.GetAllCandidates();

        }
    }
}
