using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cvjećarnica_Zvončica.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rola",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rola",
                table: "AspNetUsers");
        }
    }
}
