using Microsoft.EntityFrameworkCore.Migrations;

namespace IsAramaOtomasyonu.FluentAPI.DAL.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FringeBenefits",
                keyColumn: "FringeBenefitId",
                keyValue: 2,
                column: "Description",
                value: "Yemek (Sodexo)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FringeBenefits",
                keyColumn: "FringeBenefitId",
                keyValue: 2,
                column: "Description",
                value: "Yemek (Sodexe)");
        }
    }
}
