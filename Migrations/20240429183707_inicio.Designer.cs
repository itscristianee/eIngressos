﻿// <auto-generated />
using System;
using Ing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ing.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240429183707_inicio")]
    partial class inicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ing.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActorId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.ToTable("Actores");
                });

            modelBuilder.Entity("Ing.Models.Actor_Filme", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<string>("Papel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId", "FilmeId");

                    b.HasIndex("FilmeId");

                    b.ToTable("Actores_Filmes");
                });

            modelBuilder.Entity("Ing.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<DateOnly>("DataNasc")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Ing.Models.Filmes", b =>
                {
                    b.Property<int>("FilmeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmeId"));

                    b.Property<int>("ClassificacaoEtaria")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAdd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<bool>("EmExib")
                        .HasColumnType("bit");

                    b.Property<int>("FilmeCategoria")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<string>("Produtor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessaoId")
                        .HasColumnType("int");

                    b.HasKey("FilmeId");

                    b.HasIndex("SessaoId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Ing.Models.Funcionarios", b =>
                {
                    b.Property<int>("FuncId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncId"));

                    b.Property<DateOnly>("DataNasc")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("FuncId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Ing.Models.Sessao", b =>
                {
                    b.Property<int>("SessaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessaoId"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Hora")
                        .HasColumnType("time");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("nLugares")
                        .HasColumnType("int");

                    b.HasKey("SessaoId");

                    b.HasIndex("FilmeId")
                        .IsUnique();

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("Ing.Models.Actor_Filme", b =>
                {
                    b.HasOne("Ing.Models.Actor", "Actor")
                        .WithMany("Actores_Filmes")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ing.Models.Filmes", "Filmes")
                        .WithMany("Actores_Filmes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Filmes");
                });

            modelBuilder.Entity("Ing.Models.Filmes", b =>
                {
                    b.HasOne("Ing.Models.Sessao", "Sessao")
                        .WithMany()
                        .HasForeignKey("SessaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sessao");
                });

            modelBuilder.Entity("Ing.Models.Sessao", b =>
                {
                    b.HasOne("Ing.Models.Filmes", "Filmes")
                        .WithOne()
                        .HasForeignKey("Ing.Models.Sessao", "FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filmes");
                });

            modelBuilder.Entity("Ing.Models.Actor", b =>
                {
                    b.Navigation("Actores_Filmes");
                });

            modelBuilder.Entity("Ing.Models.Filmes", b =>
                {
                    b.Navigation("Actores_Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
