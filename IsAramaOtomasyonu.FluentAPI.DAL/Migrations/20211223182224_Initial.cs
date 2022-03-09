using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsAramaOtomasyonu.FluentAPI.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobRight = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "FringeBenefits",
                columns: table => new
                {
                    FringeBenefitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FringeBenefits", x => x.FringeBenefitId);
                });

            migrationBuilder.CreateTable(
                name: "ObjectionableWords",
                columns: table => new
                {
                    ObjectionableWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectionableWords", x => x.ObjectionableWordId);
                });

            migrationBuilder.CreateTable(
                name: "QualityScores",
                columns: table => new
                {
                    QualityScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Point = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityScores", x => x.QualityScoreId);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quality = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobType = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FringeBenefitJob",
                columns: table => new
                {
                    FringeBenefitsFringeBenefitId = table.Column<int>(type: "int", nullable: false),
                    JobsJobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FringeBenefitJob", x => new { x.FringeBenefitsFringeBenefitId, x.JobsJobId });
                    table.ForeignKey(
                        name: "FK_FringeBenefitJob_FringeBenefits_FringeBenefitsFringeBenefitId",
                        column: x => x.FringeBenefitsFringeBenefitId,
                        principalTable: "FringeBenefits",
                        principalColumn: "FringeBenefitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FringeBenefitJob_Jobs_JobsJobId",
                        column: x => x.JobsJobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FringeBenefits",
                columns: new[] { "FringeBenefitId", "Description" },
                values: new object[,]
                {
                    { 1, "Yol" },
                    { 2, "Yemek (Sodexe)" },
                    { 3, "Çay Kahve Parası" },
                    { 4, "Servis" }
                });

            migrationBuilder.InsertData(
                table: "ObjectionableWords",
                columns: new[] { "ObjectionableWordId", "Word" },
                values: new object[,]
                {
                    { 1, "beceriksiz" },
                    { 2, "aptal" },
                    { 3, "salak" }
                });

            migrationBuilder.InsertData(
                table: "QualityScores",
                columns: new[] { "QualityScoreId", "Description", "Point" },
                values: new object[,]
                {
                    { 1, "Type Specified", (byte)1 },
                    { 2, "Salary Specified", (byte)1 },
                    { 3, "Fringe Benefit Specified", (byte)1 },
                    { 4, "Not Use Objectionable Words", (byte)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Phone",
                table: "Company",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FringeBenefitJob_JobsJobId",
                table: "FringeBenefitJob",
                column: "JobsJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityScores_Description",
                table: "QualityScores",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FringeBenefitJob");

            migrationBuilder.DropTable(
                name: "ObjectionableWords");

            migrationBuilder.DropTable(
                name: "QualityScores");

            migrationBuilder.DropTable(
                name: "FringeBenefits");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
