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
    public class SkillServiceTest
    {
        private HrContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<HrContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new HrContext(options);

            context.Skills.AddRange(
               new Skill { id = 1, name = "C#" },
               new Skill { id = 2, name = "Java" }
            );

            context.SaveChanges();

            return context;
        }

        [Theory]
        [InlineData(3,"c#")]
        [InlineData(4,"java")]
        [InlineData(5,"python")]
        public void AddSkill_Test(int idS,string nameS)
        {
            var context = GetInMemoryDbContext();
            var service = new SkillService(context);
            var skill = new Skill(idS,nameS);
            service.AddSkill(skill);
            context.SaveChanges();
            Assert.Equal(idS, skill.id);
            Assert.Equal(nameS, skill.name);
         
        }

        [Fact]
        public void SeeAllSkills_Test()
        {
            var context = GetInMemoryDbContext();
            var service = new SkillService(context);
            var skill = service.SeeAllSkills();
            Assert.NotNull(skill);
        }
    }
}
