using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Hairdresser.Data.Migrations
{
    public partial class UserTableCityCountyAdded5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitute",
                table: "Venues",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "Latitute",
                table: "Venues",
                newName: "Latitude");

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Venues",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Venues");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Venues",
                newName: "Longitute");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Venues",
                newName: "Latitute");
        }
    }
}
