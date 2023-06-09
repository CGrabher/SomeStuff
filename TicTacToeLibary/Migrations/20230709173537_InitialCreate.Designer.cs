﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacToeLibary.Database;

#nullable disable

namespace TicTacToeLibary.Migrations
{
    [DbContext(typeof(TicTacToeDatabaseContext))]
    [Migration("20230709173537_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("TicTacToeLibary.Players.GameResult", b =>
                {
                    b.Property<int>("GameResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameResultId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GameResults");
                });

            modelBuilder.Entity("TicTacToeLibary.Players.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Player");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Player");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TicTacToeLibary.Players.HumanPlayer", b =>
                {
                    b.HasBaseType("TicTacToeLibary.Players.Player");

                    b.HasDiscriminator().HasValue("HumanPlayer");
                });

            modelBuilder.Entity("TicTacToeLibary.Players.GameResult", b =>
                {
                    b.HasOne("TicTacToeLibary.Players.Player", "Player")
                        .WithMany("GameResults")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TicTacToeLibary.Players.Player", b =>
                {
                    b.Navigation("GameResults");
                });
#pragma warning restore 612, 618
        }
    }
}
