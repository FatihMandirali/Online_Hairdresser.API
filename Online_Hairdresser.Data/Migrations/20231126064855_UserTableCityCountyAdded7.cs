using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Hairdresser.Data.Migrations
{
    public partial class UserTableCityCountyAdded7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenueType",
                table: "Venues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VenueType",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VenueType",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "VenueType",
                table: "Services");
        }
    }
}
