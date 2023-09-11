using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlMarket.MVC.Migrations
{
    public partial class AddElaqeAndHaqqimizdaAndTekliflerEntityToHeaderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeaderId",
                table: "Tekliflers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeaderId",
                table: "Haqqimizdas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeaderId",
                table: "Elaqes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tekliflers_HeaderId",
                table: "Tekliflers",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Haqqimizdas_HeaderId",
                table: "Haqqimizdas",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Elaqes_HeaderId",
                table: "Elaqes",
                column: "HeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elaqes_Headers_HeaderId",
                table: "Elaqes",
                column: "HeaderId",
                principalTable: "Headers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Haqqimizdas_Headers_HeaderId",
                table: "Haqqimizdas",
                column: "HeaderId",
                principalTable: "Headers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tekliflers_Headers_HeaderId",
                table: "Tekliflers",
                column: "HeaderId",
                principalTable: "Headers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elaqes_Headers_HeaderId",
                table: "Elaqes");

            migrationBuilder.DropForeignKey(
                name: "FK_Haqqimizdas_Headers_HeaderId",
                table: "Haqqimizdas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tekliflers_Headers_HeaderId",
                table: "Tekliflers");

            migrationBuilder.DropIndex(
                name: "IX_Tekliflers_HeaderId",
                table: "Tekliflers");

            migrationBuilder.DropIndex(
                name: "IX_Haqqimizdas_HeaderId",
                table: "Haqqimizdas");

            migrationBuilder.DropIndex(
                name: "IX_Elaqes_HeaderId",
                table: "Elaqes");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "Tekliflers");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "Haqqimizdas");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "Elaqes");
        }
    }
}
