using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatinhasQueBrilham.Migrations
{
    public partial class IntermediadoEAdotanteAdocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quadupla",
                table: "adocao",
                newName: "Quadrupla");

            migrationBuilder.CreateTable(
                name: "adotante",
                columns: table => new
                {
                    AdotanteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    DtNascimento = table.Column<DateTime>(nullable: false),
                    RG = table.Column<int>(nullable: false),
                    CPF = table.Column<int>(nullable: false),
                    CEP = table.Column<int>(nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    NroEndereco = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Profissao = table.Column<string>(nullable: true),
                    TelRes = table.Column<string>(nullable: true),
                    TelCel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adotante", x => x.AdotanteId);
                });

            migrationBuilder.CreateTable(
                name: "intermediador",
                columns: table => new
                {
                    IntermediadorAdocaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    NroEndereco = table.Column<int>(nullable: false),
                    TelRes = table.Column<string>(nullable: true),
                    TelCel = table.Column<string>(nullable: true),
                    Ativo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intermediador", x => x.IntermediadorAdocaoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adotante");

            migrationBuilder.DropTable(
                name: "intermediador");

            migrationBuilder.RenameColumn(
                name: "Quadrupla",
                table: "adocao",
                newName: "Quadupla");
        }
    }
}
