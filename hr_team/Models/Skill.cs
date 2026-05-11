using System.ComponentModel.DataAnnotations;

namespace hr_team.Models
{
    public class Skill
    {
        public Skill(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        [Key]
        public int id { get; set; }

        public string name { get; set; }

    }
}
