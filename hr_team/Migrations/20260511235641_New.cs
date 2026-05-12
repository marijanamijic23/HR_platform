using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hr_team.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Java");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "C#");
        }
    }
}
