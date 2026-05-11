using System.ComponentModel.DataAnnotations;

namespace hr_team.Models
{
    public class Candidate
    {
        public Candidate(int id, string full_name, DateTime date_of_birth, string contact_number, string email)
        {
            this.Id = id;
            this.full_name = full_name;
            this.date_of_birth = date_of_birth;
            this.contact_number = contact_number;
            this.email = email;
        }

        [Key]
        public int Id { get; set; }
        public string full_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public string contact_number { get; set; }
        public string email { get; set; }
    }
}
