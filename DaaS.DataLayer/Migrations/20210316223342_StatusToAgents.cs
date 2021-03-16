using Microsoft.EntityFrameworkCore.Migrations;

namespace DaaS.DataLayer.Migrations
{
    public partial class StatusToAgents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Agents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Agents");
        }
    }
}
