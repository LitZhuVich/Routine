using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Routine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[,]
                {
                    { new Guid("5efc910b-2f45-43df-afae-620d40542800"), "Photoshop?", "Adobe" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542811"), "From Jiangsu", "Suning" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542822"), "- -", "360" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542833"), "Store", "Amazon" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542844"), "Is it a company?", "Firefox" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542853"), "Fubao Company", "Alipapa" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716400"), "From Beijing", "Baidu" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716411"), "Football Club", "AC Milan" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716422"), "Blocked", "Youtube" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716433"), "Music?", "NetEase" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716440"), "Don't be evil", "Google" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716444"), "Who?", "Yahoo" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237100"), "From Shenzhen", "Tencent" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237111"), "Wow", "SpaceX" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237122"), "Blocked", "Twitter" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237133"), "Brothers", "Jingdong" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237144"), "Not Exists?", "AOL" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), "Great Company", "Microsoft" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
