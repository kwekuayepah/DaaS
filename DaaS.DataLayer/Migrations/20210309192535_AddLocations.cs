using Microsoft.EntityFrameworkCore.Migrations;

namespace DaaS.DataLayer.Migrations
{
    public partial class AddLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Agents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Agents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Agents");
        }
    }
}
