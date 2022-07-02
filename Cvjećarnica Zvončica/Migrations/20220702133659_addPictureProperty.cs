using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cvjećarnica_Zvončica.Migrations
{
    public partial class addPictureProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Slika",
                table: "Proizvod",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Proizvod");
        }
    }
}
