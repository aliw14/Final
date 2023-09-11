using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlMarket.MVC.Migrations
{
    public partial class BizeYazin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BizeYazinId",
                table: "SocialNetworks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BizeYazinId",
                table: "Links",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BizeYazins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BizeYazins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_BizeYazinId",
                table: "SocialNetworks",
                column: "BizeYazinId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_BizeYazinId",
                table: "Links",
                column: "BizeYazinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_BizeYazins_BizeYazinId",
                table: "Links",
                column: "BizeYazinId",
                principalTable: "BizeYazins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetworks_BizeYazins_BizeYazinId",
                table: "SocialNetworks",
                column: "BizeYazinId",
                principalTable: "BizeYazins",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_BizeYazins_BizeYazinId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetworks_BizeYazins_BizeYazinId",
                table: "SocialNetworks");

            migrationBuilder.DropTable(
                name: "BizeYazins");

            migrationBuilder.DropIndex(
                name: "IX_SocialNetworks_BizeYazinId",
                table: "SocialNetworks");

            migrationBuilder.DropIndex(
                name: "IX_Links_BizeYazinId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "BizeYazinId",
                table: "SocialNetworks");

            migrationBuilder.DropColumn(
                name: "BizeYazinId",
                table: "Links");
        }
    }
}
