using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personnel_Records.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InititialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Personnel_Records");

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Personnel_Records",
                columns: table => new
                {
                    Payroll_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Forenames = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date_of_Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address_2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EMail_Home = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Payroll_Number);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Personnel_Records");
        }
    }
}
