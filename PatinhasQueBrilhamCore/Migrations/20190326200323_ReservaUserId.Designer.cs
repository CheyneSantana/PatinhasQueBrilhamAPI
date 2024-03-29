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
    [Migration("20190326200323_ReservaUserId")]
    partial class ReservaUserId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PatinhasQueBrilham.Models.AnimaisAdocao", b =>
                {
                    b.Property<int>("AnimaisAdocaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adotado");

                    b.Property<string>("Detalhes")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("PathFoto")
                        .IsRequired();

                    b.Property<string>("Raca")
                        .IsRequired();

                    b.HasKey("AnimaisAdocaoId");

                    b.ToTable("adocao");
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

                    b.Property<string>("nomeDono")
                        .IsRequired();

                    b.Property<string>("nomePet")
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

                    b.HasKey("Id");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
