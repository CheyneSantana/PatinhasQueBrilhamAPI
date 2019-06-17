using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class capa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idadePet",
                table: "reserva",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "portePet",
                table: "reserva",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "capa",
                columns: table => new
                {
                    capaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    path = table.Column<string>(nullable: false),
                    titulo = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    link = table.Column<string>(nullable: true),
                    ativo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_capa", x => x.capaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "capa");

            migrationBuilder.DropColumn(
                name: "idadePet",
                table: "reserva");

            migrationBuilder.DropColumn(
                name: "portePet",
                table: "reserva");
        }
    }
}
