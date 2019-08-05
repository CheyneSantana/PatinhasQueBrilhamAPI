using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class AlteracaoAnimaisAdocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PathFoto",
                table: "adocao",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PathFoto",
                table: "adocao",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
