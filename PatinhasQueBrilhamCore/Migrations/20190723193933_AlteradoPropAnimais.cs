using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class AlteradoPropAnimais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adotado",
                table: "adocao",
                newName: "Ativo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "adocao",
                newName: "Adotado");
        }
    }
}
