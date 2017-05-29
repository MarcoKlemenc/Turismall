using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turismall.Data.Migrations
{
    public partial class Fechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Viaje",
                newName: "FechaInicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Viaje",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Viaje");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Viaje",
                newName: "Fecha");
        }
    }
}
