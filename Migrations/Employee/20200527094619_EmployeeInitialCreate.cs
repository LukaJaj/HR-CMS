using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrProject.Migrations.Employee
{
    public partial class EmployeeInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeModels",
                columns: table => new
                {
                    PrivateId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    DateOfFire = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeModels", x => x.PrivateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeModels");
        }
    }
}
