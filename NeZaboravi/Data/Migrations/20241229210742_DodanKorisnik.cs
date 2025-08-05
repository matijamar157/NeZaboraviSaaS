using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeZaboravi.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodanKorisnik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username10 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik");

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
    }
}
