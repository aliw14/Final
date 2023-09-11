using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlMarket.MVC.Migrations
{
    public partial class AddFooterToNavbarEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NavbarId",
                table: "Footers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Footers_NavbarId",
                table: "Footers",
                column: "NavbarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Footers_Navbars_NavbarId",
                table: "Footers",
                column: "NavbarId",
                principalTable: "Navbars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footers_Navbars_NavbarId",
                table: "Footers");

            migrationBuilder.DropIndex(
                name: "IX_Footers_NavbarId",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "NavbarId",
                table: "Footers");
        }
    }
}
