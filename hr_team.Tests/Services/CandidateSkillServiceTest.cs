using hr_team.Data;
using hr_team.Models;
using hr_team.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_team.Tests.Services
{
    public class CandidateSkillServiceTest
    {
        private HrContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<HrContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new HrContext(options);

            context.CandidateSkills.AddRange(
                new CandidateSkill { CandidateId = 1, SkillId = 1 },
                new CandidateSkill { CandidateId = 2,SkillId = 2 }
            );

            context.SaveChanges();

            return context;
        }

        [Fact]
        public void ShowAllElements_Test()
        {
            var context = GetInMemoryDbContext();
            var service = new CandidateSkillService(context);
            var result = service.ShowAllElements();
            Assert.NotNull(result);
        }
    }
}
