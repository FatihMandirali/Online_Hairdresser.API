using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Hairdresser.Data.Migrations
{
    public partial class UserTableCityCountyAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CityCounties_CityCountyId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CityCountyId",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CityCounties_CityCountyId",
                table: "Users",
                column: "CityCountyId",
                principalTable: "CityCounties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CityCounties_CityCountyId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CityCountyId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CityCounties_CityCountyId",
                table: "Users",
                column: "CityCountyId",
                principalTable: "CityCounties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
