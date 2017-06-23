using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turismall.Data.Migrations
{
    public partial class LinkPronostico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkPronostico",
                table: "Destino",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LugarPronostico",
                table: "Destino",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkPronostico",
                table: "Destino");

            migrationBuilder.DropColumn(
                name: "LugarPronostico",
                table: "Destino");
        }
    }
}
