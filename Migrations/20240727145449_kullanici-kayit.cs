using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzmRehber.Migrations
{
    /// <inheritdoc />
    public partial class kullanicikayit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "users");
        }
    }
}
