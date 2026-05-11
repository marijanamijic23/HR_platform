using hr_team.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hr_team.Configuration
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidates");

            builder.HasData(
                new Candidate
                {
                    id = 1,
                    full_name = "John Doe",
                    date_of_birth = new DateTime(1990, 1, 1),
                    contact_number = "1234567890",
                    email = "johndoe23@gmail.com"
                },
                new Candidate
                {
                    id = 2,
                    full_name = "Jane Smith",
                    date_of_birth = new DateTime(1992, 5, 15),
                    contact_number = "0987654321",
                    email = "janesmith@gmail.com"
                },
                new Candidate
                {
                    id = 3,
                    full_name = "Michael Johnson",
                    date_of_birth = new DateTime(1988, 10, 20),
                    contact_number = "5551234567",
                    email = "michaeljohnson@gmail.com"
                }
            );
        }
    }
}
