using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turismall.Data.Migrations
{
    public partial class FotoNota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "texto",
                table: "Nota",
                newName: "Texto");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Nota",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "Nota",
                newName: "texto");
        }
    }
}
