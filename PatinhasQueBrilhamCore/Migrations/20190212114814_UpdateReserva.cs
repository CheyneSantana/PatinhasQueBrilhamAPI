using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class UpdateReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "raca",
                table: "reserva",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipoPet",
                table: "reserva",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "raca",
                table: "reserva");

            migrationBuilder.DropColumn(
                name: "tipoPet",
                table: "reserva");
        }
    }
}
