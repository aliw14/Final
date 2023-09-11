using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlMarket.MVC.Migrations
{
    public partial class HeaderAndNavbar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NavbarId",
                table: "Tekliflers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NavbarId",
                table: "Haqqimizdas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NavbarId",
                table: "Elaqes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Headers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Navbars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nav = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navbars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Navbars_Headers_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "Headers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tekliflers_NavbarId",
                table: "Tekliflers",
                column: "NavbarId");

            migrationBuilder.CreateIndex(
                name: "IX_Haqqimizdas_NavbarId",
                table: "Haqqimizdas",
                column: "NavbarId");

            migrationBuilder.CreateIndex(
                name: "IX_Elaqes_NavbarId",
                table: "Elaqes",
                column: "NavbarId");

            migrationBuilder.CreateIndex(
                name: "IX_Navbars_HeaderId",
                table: "Navbars",
                column: "HeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elaqes_Navbars_NavbarId",
                table: "Elaqes",
                column: "NavbarId",
                principalTable: "Navbars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Haqqimizdas_Navbars_NavbarId",
                table: "Haqqimizdas",
                column: "NavbarId",
                principalTable: "Navbars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tekliflers_Navbars_NavbarId",
                table: "Tekliflers",
                column: "NavbarId",
                principalTable: "Navbars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elaqes_Navbars_NavbarId",
                table: "Elaqes");

            migrationBuilder.DropForeignKey(
                name: "FK_Haqqimizdas_Navbars_NavbarId",
                table: "Haqqimizdas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tekliflers_Navbars_NavbarId",
                table: "Tekliflers");

            migrationBuilder.DropTable(
                name: "Navbars");

            migrationBuilder.DropTable(
                name: "Headers");

            migrationBuilder.DropIndex(
                name: "IX_Tekliflers_NavbarId",
                table: "Tekliflers");

            migrationBuilder.DropIndex(
                name: "IX_Haqqimizdas_NavbarId",
                table: "Haqqimizdas");

            migrationBuilder.DropIndex(
                name: "IX_Elaqes_NavbarId",
                table: "Elaqes");

            migrationBuilder.DropColumn(
                name: "NavbarId",
                table: "Tekliflers");

            migrationBuilder.DropColumn(
                name: "NavbarId",
                table: "Haqqimizdas");

            migrationBuilder.DropColumn(
                name: "NavbarId",
                table: "Elaqes");
        }
    }
}
