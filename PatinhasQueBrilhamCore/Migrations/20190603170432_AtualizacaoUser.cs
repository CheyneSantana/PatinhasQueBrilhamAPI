using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class AtualizacaoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelCel",
                table: "user",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelRes",
                table: "user",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelCel",
                table: "user");

            migrationBuilder.DropColumn(
                name: "TelRes",
                table: "user");
        }
    }
}
