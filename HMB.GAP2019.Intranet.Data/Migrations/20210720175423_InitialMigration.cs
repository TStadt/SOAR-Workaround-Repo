using Microsoft.EntityFrameworkCore.Migrations;

namespace HMB.GAP2019.Intranet.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 300, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "alice.jones.admin@hmbnet.com", "Alice", "Jones" },
                    { 2, "john.smith.employee@hmbnet.com", "John", "Smith" },
                    { 3, "pamela.rogers.pm@hmbnet.com", "Pamela", "Rogers" },
                    { 4, "carter.cruz.hr@hmbnet.com", "Carter", "Cruz" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
