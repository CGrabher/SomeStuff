﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacToeLibary.Database;

#nullable disable

namespace TicTacToeLibary.Migrations
{
    [DbContext(typeof(TicTacToeDatabaseContext))]
    [Migration("20230712054826_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("TicTacToeLibary.Database.GameResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Player1Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Player2Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Timestamp")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Timezone")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("GameResults");
                });
#pragma warning restore 612, 618
        }
    }
}
