using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Hairdresser.Data.Migrations
{
    public partial class UserIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_Id",
                table: "Themes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Onboardings_Id",
                table: "Onboardings",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Themes_Id",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Onboardings_Id",
                table: "Onboardings");
        }
    }
}
