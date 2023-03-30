using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Hairdresser.Data.Migrations
{
    public partial class EditTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Onboardings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Onboardings");
        }
    }
}
