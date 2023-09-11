using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlMarket.MVC.Migrations
{
    public partial class AddFooterIcollectionToHeaderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeaderId",
                table: "Footers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Footers_HeaderId",
                table: "Footers",
                column: "HeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Footers_Headers_HeaderId",
                table: "Footers",
                column: "HeaderId",
                principalTable: "Headers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footers_Headers_HeaderId",
                table: "Footers");

            migrationBuilder.DropIndex(
                name: "IX_Footers_HeaderId",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "Footers");
        }
    }
}
