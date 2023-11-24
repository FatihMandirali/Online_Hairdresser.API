using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Hairdresser.Data.Migrations
{
    public partial class UserTableCityCountyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CityCountyId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityCountyId",
                table: "Users",
                column: "CityCountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CityCounties_CityCountyId",
                table: "Users",
                column: "CityCountyId",
                principalTable: "CityCounties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CityCounties_CityCountyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CityCountyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CityCountyId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
