using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reserva",
                columns: table => new
                {
                    reservaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nomeDono = table.Column<string>(nullable: true),
                    nomePet = table.Column<string>(nullable: true),
                    residencial = table.Column<string>(nullable: true),
                    celular = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    comentario = table.Column<string>(nullable: true),
                    fromDate = table.Column<string>(nullable: true),
                    toDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserva", x => x.reservaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reserva");
        }
    }
}
