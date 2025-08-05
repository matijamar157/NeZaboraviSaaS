using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeZaboravi.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username10",
                table: "Artikl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username2",
                table: "Artikl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username3",
                table: "Artikl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username4",
                table: "Artikl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username5",
                table: "Artikl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username6",
                table: "Artikl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username7",
                table: "Artikl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username8",
                table: "Artikl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username9",
                table: "Artikl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username10",
                table: "Artikl");

            migrationBuilder.DropColumn(
                name: "Username2",
                table: "Artikl");

            migrationBuilder.DropColumn(
                name: "Username3",
                table: "Artikl");

            migrationBuilder.DropColumn(
                name: "Username4",
                table: "Artikl");

            migrationBuilder.DropColumn(
                name: "Username5",
                table: "Artikl");

            migrationBuilder.DropColumn(
                name: "Username6",
                table: "Artikl");

            migrationBuilder.DropColumn(
                name: "Username7",
                table: "Artikl");

            migrationBuilder.DropColumn(
                name: "Username8",
                table: "Artikl");

            migrationBuilder.DropColumn(
                name: "Username9",
                table: "Artikl");
        }
    }
}
