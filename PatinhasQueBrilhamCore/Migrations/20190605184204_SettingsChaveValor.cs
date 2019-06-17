using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class SettingsChaveValor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "settings",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "settings",
                newName: "Chave");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "settings",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Chave",
                table: "settings",
                newName: "Key");
        }
    }
}
