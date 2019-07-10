using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class AlteradoCapa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                table: "capa");

            migrationBuilder.DropColumn(
                name: "titulo",
                table: "capa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "capa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "titulo",
                table: "capa",
                nullable: true);
        }
    }
}
