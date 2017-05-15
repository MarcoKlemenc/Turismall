using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turismall.Data.Migrations
{
    public partial class Nota2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Viaje_viajeID",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "viajeID",
                table: "Nota",
                newName: "ViajeID");

            migrationBuilder.RenameIndex(
                name: "IX_Nota_viajeID",
                table: "Nota",
                newName: "IX_Nota_ViajeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Viaje_ViajeID",
                table: "Nota",
                column: "ViajeID",
                principalTable: "Viaje",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Viaje_ViajeID",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "ViajeID",
                table: "Nota",
                newName: "viajeID");

            migrationBuilder.RenameIndex(
                name: "IX_Nota_ViajeID",
                table: "Nota",
                newName: "IX_Nota_viajeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Viaje_viajeID",
                table: "Nota",
                column: "viajeID",
                principalTable: "Viaje",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
