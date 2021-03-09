using Microsoft.EntityFrameworkCore.Migrations;

namespace DaaS.DataLayer.Migrations
{
    public partial class AgentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    MotorNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    AccountType = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    AccountProvider = table.Column<string>(nullable: true),
                    AccountCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
