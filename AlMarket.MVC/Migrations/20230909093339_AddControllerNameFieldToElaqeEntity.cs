using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlMarket.MVC.Migrations
{
    public partial class AddControllerNameFieldToElaqeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "Elaqes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "Elaqes");
        }
    }
}
