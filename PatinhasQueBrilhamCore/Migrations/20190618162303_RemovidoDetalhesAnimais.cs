using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class RemovidoDetalhesAnimais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalhes",
                table: "adocao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detalhes",
                table: "adocao",
                nullable: false,
                defaultValue: "");
        }
    }
}
