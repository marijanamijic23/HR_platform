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
        ICandidateChangeValueRepository _candidateChangeValueRepository;
        ICandidateGetValuesRepository _candidateGetValuesRepository;
        ISkillRepository _skillRepository;
        ICandidateSkillRepository _candidateSkillRepository;
        public HrController(ICandidateChangeValueRepository change, ICandidateGetValuesRepository get, ISkillRepository skill, ICandidateSkillRepository candidateSkill)
        {
            _candidateChangeValueRepository = change;
            _candidateGetValuesRepository = get;
            _skillRepository = skill;
            _candidateSkillRepository = candidateSkill;
        }

        [HttpPost]
        [Route("AddCandidate")]
        public string AddJobCandidate(Candidate candidate)
        {
            _candidateChangeValueRepository.AddJobCandidate(candidate);
            if (_candidateChangeValueRepository.GetStatus() == 1)
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
            _candidateChangeValueRepository.RemoveCandidate(candidateId);

            if (_candidateChangeValueRepository.GetStatus() == 1)
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
            var search = _candidateGetValuesRepository.SearchCandidatesByName(name);
            if (_candidateGetValuesRepository.getStatus() == 1)
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
            var search = _candidateGetValuesRepository.SearchCandidateByGivenSkill(skill);
            if (_candidateGetValuesRepository.getStatus() == 1)
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
            _candidateChangeValueRepository.UpdateJobCandidateWithSkills(candidateId, name);
            if (_candidateChangeValueRepository.GetStatus() == 1)
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
            _candidateChangeValueRepository.RemoveSkillsFromJobCandidate(candidateId);
            if (_candidateChangeValueRepository.GetStatus() == 1)
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
            _skillRepository.Add_skill(skill);
            if (_skillRepository.getStatus() == 1)
            {
                this.HttpContext.Response.StatusCode = 400;
                return "Skill with this name already exists!";
            }

            if (_skillRepository.getStatus() == 2)
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
            return _skillRepository.SeeAllSkills();
        }

        [HttpGet]
        [Route("GetAllCandidates")]
        public List<Candidate> GetAllCandidates()
        {
            return _candidateGetValuesRepository.GetAllCandidates();

        }

        [HttpGet]
        [Route("ShowAllElements")]
        public List<CandidateSkill> ShowAllElements()
        {
            return _candidateSkillRepository.ShowAllElements();
        }
    }
}
