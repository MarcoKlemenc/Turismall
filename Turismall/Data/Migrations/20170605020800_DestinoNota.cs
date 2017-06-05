using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turismall.Data.Migrations
{
    public partial class DestinoNota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinoID",
                table: "Nota",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nota_DestinoID",
                table: "Nota",
                column: "DestinoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Destino_DestinoID",
                table: "Nota",
                column: "DestinoID",
                principalTable: "Destino",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Destino_DestinoID",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_DestinoID",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "DestinoID",
                table: "Nota");
        }
    }
}
