using Microsoft.EntityFrameworkCore.Migrations;

namespace Cvjećarnica_Zvončica.Migrations
{
    public partial class prosiri_model_proizvod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Proizvod",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Proizvod");
        }
    }
}
