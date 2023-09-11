using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlMarket.MVC.Migrations
{
    public partial class MarketAndHuquq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Marketid",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filials = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Huquqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marketid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huquqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huquqs_Markets_Marketid",
                        column: x => x.Marketid,
                        principalTable: "Markets",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_Marketid",
                table: "Medias",
                column: "Marketid");

            migrationBuilder.CreateIndex(
                name: "IX_Huquqs_Marketid",
                table: "Huquqs",
                column: "Marketid");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Markets_Marketid",
                table: "Medias",
                column: "Marketid",
                principalTable: "Markets",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Markets_Marketid",
                table: "Medias");

            migrationBuilder.DropTable(
                name: "Huquqs");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropIndex(
                name: "IX_Medias_Marketid",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Marketid",
                table: "Medias");
        }
    }
}
