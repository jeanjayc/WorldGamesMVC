﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorldGamesMVC.Context;

namespace WorldGamesMVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210918171128_identit")]
    partial class identit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("WorldGamesMVC.Models.CarrinhoCompraItem", b =>
                {
                    b.Property<int>("CarrinhoCompraItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CarrinhoCompraId")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CarrinhoCompraItemId");

                    b.HasIndex("GameId");

                    b.ToTable("CarrinhoCompraItens");
                });

            modelBuilder.Entity("WorldGamesMVC.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<sbyte>("Ativo")
                        .HasColumnType("tinyint");

                    b.Property<string>("DescricaoCompleta")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("DescricaoCurta")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("ImagemThumb")
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("Lancamento")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Plataforma")
                        .HasColumnType("int");

                    b.Property<float>("Preco")
                        .HasColumnType("FLOAT(10,6)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("GameId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WorldGamesMVC.Models.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GeneroNome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("WorldGamesMVC.Models.CarrinhoCompraItem", b =>
                {
                    b.HasOne("WorldGamesMVC.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("WorldGamesMVC.Models.Game", b =>
                {
                    b.HasOne("WorldGamesMVC.Models.Genero", "Genero")
                        .WithMany("Games")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("WorldGamesMVC.Models.Genero", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
