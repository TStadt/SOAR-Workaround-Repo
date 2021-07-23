using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CGI.SOAR.Intranet.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsHighPriority = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    Body = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    IsNoteRequired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedEmployeeId = table.Column<int>(nullable: false),
                    AssignedTaskId = table.Column<int>(nullable: false),
                    MondayOfWeek = table.Column<DateTime>(nullable: false),
                    Monday = table.Column<double>(nullable: false),
                    Tuesday = table.Column<double>(nullable: false),
                    Wednesday = table.Column<double>(nullable: false),
                    Thursday = table.Column<double>(nullable: false),
                    Friday = table.Column<double>(nullable: false),
                    Saturday = table.Column<double>(nullable: false),
                    Sunday = table.Column<double>(nullable: false),
                    Note = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeEntries_Employees_AssignedEmployeeId",
                        column: x => x.AssignedEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeEntries_Tasks_AssignedTaskId",
                        column: x => x.AssignedTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "Body", "EndDate", "IsHighPriority", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, @"##About
                This is a markdown file. for more information about markdown please go to [this site](https://www.markdownguide.org/cheat-sheet)
                ", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Welcome to the Angular portion of the Grad Academy Project" },
                    { 2, @"##Members
                * Anna Buchy
                * Anthony Huck
                * Brynna Johnson
                * Josh Seltzer
                * Keegan Moore
                * Nishil Shah
                * Randy Skripac
                ", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Grad Academy Information" },
                    { 3, @"##Project Breakdown
                * Front end: [Angular](https://angular.io/)
                * API: [ASP.NET Core 3.1 Web API](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
                * Database: [LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sqlallproducts-allversions)
                ", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Welcome to the Grad Academy Presentation!" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "alice.jones.admin@cgi.com", "Alice", "Jones" },
                    { 2, "john.smith.employee@cgi.com", "John", "Smith" },
                    { 3, "pamela.rogers.pm@cgi.com", "Pamela", "Rogers" },
                    { 4, "carter.cruz.hr@cgi.com", "Carter", "Cruz" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "IsNoteRequired", "Name" },
                values: new object[,]
                {
                    { 9, false, "Release Management" },
                    { 8, false, "Project Management" },
                    { 7, false, "Out of Office" },
                    { 6, true, "Other" },
                    { 2, false, "Design" },
                    { 4, false, "Marketing" },
                    { 3, false, "Develop" },
                    { 10, false, "Requirements" },
                    { 1, false, "Deployment" },
                    { 5, false, "Meeting" },
                    { 11, false, "Testing" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_AssignedEmployeeId",
                table: "TimeEntries",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_AssignedTaskId",
                table: "TimeEntries",
                column: "AssignedTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "TimeEntries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
