namespace hr_team.Models
{
    public class Candidate
    {
        public Candidate(int id, string full_name, DateTime date_of_birth, string contact_number, string email)
        {
            this.id = id;
            this.full_name = full_name;
            this.date_of_birth = date_of_birth;
            this.contact_number = contact_number;
            this.email = email;
        }

        private int id { get; set; }
        private string full_name { get; set; }
        private DateTime date_of_birth { get; set; }
        private string contact_number { get; set; }
        private string email { get; set; }
    }
}
