using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class atualizacaoAnimaisAdocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "adocao",
                newName: "NomeAtual");

            migrationBuilder.AddColumn<int>(
                name: "Adulto",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Castrado",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CorPelagem",
                table: "adocao",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Dose",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Especie",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Microchip",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeAntigo",
                table: "adocao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Porte",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quadupla",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RGA",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Raiva",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "V10",
                table: "adocao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vermifugado",
                table: "adocao",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adulto",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Castrado",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "CorPelagem",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Dose",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Especie",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Microchip",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "NomeAntigo",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Porte",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Quadupla",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "RGA",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Raiva",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "V10",
                table: "adocao");

            migrationBuilder.DropColumn(
                name: "Vermifugado",
                table: "adocao");

            migrationBuilder.RenameColumn(
                name: "NomeAtual",
                table: "adocao",
                newName: "Nome");
        }
    }
}
