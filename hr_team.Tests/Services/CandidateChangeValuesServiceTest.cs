using hr_team.Data;
using hr_team.Models;
using hr_team.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hr_team.Tests.Services
{
    public class CandidateChangeValuesServiceTest
    {
        private HrContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<HrContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new HrContext(options);

            context.Candidates.AddRange(
                new Candidate { id = 1, full_name = "John Doe", date_of_birth = new DateTime(1990, 1, 1), contact_number = "1234567890", email = "johndoe@gmail.com" },
                new Candidate { id = 2, full_name = "Jane Smith", date_of_birth = new DateTime(1992, 2, 2), contact_number = "0987654321", email = "janesmith@gmail.com" }
            );

            context.SaveChanges();

            return context;
        }

        [Theory]
        [InlineData(3,"Ana Anic","1999-12-12","0658798725","anaanic@gmail.com")]
        [InlineData(4,"Sara Saric","2004-06-12","0656789087","sarasaric@gmail.com")]
        [InlineData(5,"Marko Markovic","2001-03-05","0678967545","markomarkovic@gmail.com")]
        public void AddJobCandidate_Test(int idC,string name,string date,string phone_number,string gmail)
        {
            var context = GetInMemoryDbContext();
            var service = new CandidateChangeValuesService(context);

            var el = DateTime.ParseExact(date,"yyyy-MM-dd",CultureInfo.InvariantCulture);
            var newCandidate = new Candidate { id = idC, full_name = name, date_of_birth = el, contact_number = phone_number, email = gmail };
            service.AddJobCandidate(newCandidate);

            var candidateInDb = context.Candidates.Find(idC);
            Assert.NotNull(candidateInDb);
            Assert.Equal(name, candidateInDb.full_name);
            Assert.Equal(el, candidateInDb.date_of_birth);
            Assert.Equal(phone_number, candidateInDb.contact_number);
            Assert.Equal(gmail, candidateInDb.email);
        }



        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void RemoveCandidate_Test(int idS)
        {
            var context = GetInMemoryDbContext();
            var service = new CandidateChangeValuesService(context);
            service.RemoveCandidate(idS);
            var candidateInDb = context.Candidates.Find(idS);
            Assert.Null(candidateInDb);
        }

        [Theory]
        [InlineData(1,1,"c#")]
        [InlineData(2,2,"java")]
        [InlineData(1,2,"python")]
        public void UpdateJobCandidateWithSkills_Test(int canId,int sId,string nameS)
        {
            var context = GetInMemoryDbContext();
            var service = new CandidateChangeValuesService(context);
            var skill = new Skill { id = sId, name = nameS };
            context.Skills.Add(skill);
            context.SaveChanges();
            service.UpdateJobCandidateWithSkills(canId, nameS);
            var candidateSkillInDb = context.CandidateSkills.Where(cs => cs.CandidateId == canId && cs.SkillId == sId).FirstOrDefault();
            Assert.NotNull(candidateSkillInDb);
        }

        [Theory]
        [InlineData(1,1,"c#")]
        [InlineData(2,2,"python")]
        [InlineData(3,3,"java")]
        public void RemoveSkillsFromJobCandidate_Test(int canId,int sId,string name)
        {
            var context = GetInMemoryDbContext();
            var service = new CandidateChangeValuesService(context);
            var skill = new Skill { id = sId, name = name };
            context.Skills.Add(skill);
            context.CandidateSkills.Add(new CandidateSkill { CandidateId = canId, SkillId = sId });
            context.SaveChanges();
            service.RemoveSkillsFromJobCandidate(1);
            var candidateSkillInDb = context.CandidateSkills.Where(cs => cs.CandidateId == canId && cs.SkillId == sId).FirstOrDefault();

        }
    }
}
