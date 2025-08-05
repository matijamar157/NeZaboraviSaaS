﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeZaboravi.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodanNoviProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Korisnik");
        }
    }
}
