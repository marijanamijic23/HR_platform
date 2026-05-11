using hr_team.Models;
using hr_team.Repository;
using hr_team.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net;

namespace hr_team.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrController : ControllerBase
    {
        ICandidateChangeValueService _candidateChangeValueService;
        ICandidateGetValuesService _candidateGetValuesService;
        ISkillService _skillService;
        ICandidateSkillService _candidateSkillService;
        public HrController(ICandidateChangeValueService change, ICandidateGetValuesService get, ISkillService skill, ICandidateSkillService candidateSkill)
        {
            _candidateChangeValueService = change;
            _candidateGetValuesService = get;
            _skillService = skill;
            _candidateSkillService = candidateSkill;
        }

        [HttpPost]
        [Route("AddCandidate")]
        public string AddJobCandidate(Candidate candidate)
        {
            _candidateChangeValueService.AddJobCandidate(candidate);
            if (_candidateChangeValueService.GetStatus() == 1)
            {
                this.HttpContext.Response.StatusCode = 400;
                return "Candidate with this email already exists!";
            }
            return "OK!";
        }

        [HttpPost]
        [Route("RemoveCandidate")]
        public string RemoveCandidate(int candidateId)
        {
            _candidateChangeValueService.RemoveCandidate(candidateId);

            if (_candidateChangeValueService.GetStatus() == 1)
            {
                this.HttpContext.Response.StatusCode = 404;
                return "Candidate with this id doesn't exist!";
            }

            return "OK!";
        }

        [HttpGet]
        [Route("SearchCandidatesByName")]
        public List<Candidate> SearchCandidatesByName(string name)
        {
            var search = _candidateGetValuesService.SearchCandidatesByName(name);
            if (_candidateGetValuesService.getStatus() == 1)
            {
                this.HttpContext.Response.StatusCode = 404;
                return new List<Candidate> { new Candidate { id = 0, full_name = "No candidate found with the given name.", date_of_birth = DateTime.MinValue, contact_number = "", email = "" } };
            }

            return search;
        }

        [HttpGet]
        [Route("SearchCandidateByGivenSkill")]
        public List<Candidate> SearchCandidateByGivenSkill(string skill)
        {
            var search = _candidateGetValuesService.SearchCandidateByGivenSkill(skill);
            if (_candidateGetValuesService.getStatus() == 1)
            {
                this.HttpContext.Response.StatusCode = 404;
                return new List<Candidate> { new Candidate { id = 0, full_name = "No candidate found with the given skill.", date_of_birth = DateTime.MinValue, contact_number = "", email = "" } };
            }
            return search;
        }

        [HttpPost]
        [Route("UpdateJobCandidateWithSkills")]
        public string UpdateJobCandidateWithSkills(int candidateId, string name)
        {
            _candidateChangeValueService.UpdateJobCandidateWithSkills(candidateId, name);
            if (_candidateChangeValueService.GetStatus() == 1)
            {
                this.HttpContext.Response.StatusCode = 404;
                return "Candidate with this id doesn't exist!";
            }

            return "OK";
        }

        [HttpPost]
        [Route("RemoveSkillsFromJobCandidate")]
        public string RemoveSkillsFromJobCandidate(int candidateId)
        {
            _candidateChangeValueService.RemoveSkillsFromJobCandidate(candidateId);
            if (_candidateChangeValueService.GetStatus() == 1)
            {
                this.HttpContext.Response.StatusCode = 404;
                return "Candidate with this id doesn't exist!";
            }
            return "OK";
        }

        [HttpPost]
        [Route("AddSkill")]
        public string AddSkill(Skill skill)
        {
            _skillService.AddSkill(skill);
            if (_skillService.getStatus() == 1)
            {
                this.HttpContext.Response.StatusCode = 400;
                return "Skill with this name already exists!";
            }

            if (_skillService.getStatus() == 2)
            {
                this.HttpContext.Response.StatusCode = 400;
                return "This element already exists!";
            }

            return "OK!";
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
            return _candidateGetValuesService.GetAllCandidates();

        }

        [HttpGet]
        [Route("ShowAllElements")]
        public List<CandidateSkill> ShowAllElements()
        {
            return _candidateSkillService.ShowAllElements();
        }
    }
}
