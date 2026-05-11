using hr_team.Data;
using hr_team.Models;
using hr_team.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace hr_team.Tests.Services
{
    public class CandidateGetValuesServiceTest
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
        [InlineData("Ana Anic")]
        [InlineData("John Doe")]
        [InlineData("Jane Smith")]
        public void SearchCandidatesByName(string name)
        {
            var context = GetInMemoryDbContext();
            var service = new CandidateGetValuesService(context);
            var findCandidate = service.SearchCandidatesByName(name);
            Assert.NotNull(findCandidate);
        }

        [Theory]
        [InlineData("c#")]
        [InlineData("python")]
        [InlineData("java")]
        public void SearchCandidateByGivenSkill_Test(string skill)
        {
            var context = GetInMemoryDbContext();
            var service = new CandidateGetValuesService(context);
            var findCandidate = service.SearchCandidateByGivenSkill(skill);
            Assert.NotNull(findCandidate);
        }

        [Fact]
        public void GetAllCandidates_Test()
        {
            var context = GetInMemoryDbContext();
            var service = new CandidateGetValuesService(context);
            var findCandidate = service.GetAllCandidates();
            Assert.NotNull(findCandidate);
        }

    }
}
