﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatinhasQueBrilham.Repository;

namespace PatinhasQueBrilham.Migrations
{
    [DbContext(typeof(PatinhasContext))]
    [Migration("20190604180216_AdotanteAnimalAdocao")]
    partial class AdotanteAnimalAdocao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PatinhasQueBrilham.Models.Adotante", b =>
                {
                    b.Property<int>("AdotanteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("CEP");

                    b.Property<string>("CPF");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<DateTime>("DtNascimento");

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.Property<int>("NroEndereco");

                    b.Property<string>("Profissao");

                    b.Property<string>("RG");

                    b.Property<string>("TelCel");

                    b.Property<string>("TelRes");

                    b.Property<string>("UF");

                    b.HasKey("AdotanteId");

                    b.ToTable("adotante");
                });

            modelBuilder.Entity("PatinhasQueBrilham.Models.AdotanteAnimalAdocao", b =>
                {
                    b.Property<int>("AdotanteAnimalAdocaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdotanteId");

                    b.Property<int>("AnimaisAdocaoId");

                    b.HasKey("AdotanteAnimalAdocaoId");

                    b.ToTable("adotanteAnimalAdocao");
                });

            modelBuilder.Entity("PatinhasQueBrilham.Models.AnimaisAdocao", b =>
                {
                    b.Property<int>("AnimaisAdocaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adotado");

                    b.Property<int>("Adulto");

                    b.Property<int>("Castrado");

                    b.Property<string>("CorPelagem")
                        .IsRequired();

                    b.Property<string>("Detalhes")
                        .IsRequired();

                    b.Property<int>("Dose");

                    b.Property<int>("Especie");

                    b.Property<int>("Idade");

                    b.Property<int>("Microchip");

                    b.Property<string>("NomeAntigo");

                    b.Property<string>("NomeAtual")
                        .IsRequired();

                    b.Property<string>("PathFoto")
                        .IsRequired();

                    b.Property<int>("Porte");

                    b.Property<int>("Quadrupla");

                    b.Property<int>("RGA");

                    b.Property<string>("Raca")
                        .IsRequired();

                    b.Property<int>("Raiva");

                    b.Property<int>("Sexo");

                    b.Property<int>("V10");

                    b.Property<int>("Vermifugado");

                    b.HasKey("AnimaisAdocaoId");

                    b.ToTable("adocao");
                });

            modelBuilder.Entity("PatinhasQueBrilham.Models.Apoio", b =>
                {
                    b.Property<int>("apoioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ativo");

                    b.Property<string>("img");

                    b.Property<string>("name");

                    b.Property<string>("site");

                    b.HasKey("apoioId");

                    b.ToTable("apoio");
                });

            modelBuilder.Entity("PatinhasQueBrilham.Models.Capa", b =>
                {
                    b.Property<int>("capaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ativo");

                    b.Property<string>("descricao");

                    b.Property<string>("link");

                    b.Property<string>("path")
                        .IsRequired();

                    b.Property<string>("titulo");

                    b.HasKey("capaId");

                    b.ToTable("capa");
                });

            modelBuilder.Entity("PatinhasQueBrilham.Models.IntermediadorAdocao", b =>
                {
                    b.Property<int>("IntermediadorAdocaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ativo");

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.Property<int>("NroEndereco");

                    b.Property<string>("TelCel");

                    b.Property<string>("TelRes");

                    b.HasKey("IntermediadorAdocaoId");

                    b.ToTable("intermediador");
                });

            modelBuilder.Entity("PatinhasQueBrilham.Models.Reserva", b =>
                {
                    b.Property<int>("reservaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("celular")
                        .IsRequired();

                    b.Property<string>("comentario");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<int>("estado");

                    b.Property<DateTime>("fromDate");

                    b.Property<int>("idadePet");

                    b.Property<string>("nomeDono")
                        .IsRequired();

                    b.Property<string>("nomePet")
                        .IsRequired();

                    b.Property<string>("portePet")
                        .IsRequired();

                    b.Property<string>("raca")
                        .IsRequired();

                    b.Property<string>("residencial");

                    b.Property<int>("ticket");

                    b.Property<string>("tipoPet")
                        .IsRequired();

                    b.Property<DateTime>("toDate");

                    b.Property<int>("userId");

                    b.HasKey("reservaId");

                    b.ToTable("reserva");
                });

            modelBuilder.Entity("PatinhasQueBrilham.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Sobrenome");

                    b.Property<string>("TelCel");

                    b.Property<string>("TelRes");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
