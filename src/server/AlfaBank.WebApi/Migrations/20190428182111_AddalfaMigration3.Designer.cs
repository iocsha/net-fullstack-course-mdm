﻿// <auto-generated />
using System;
using AlfaBank.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlfaBank.WebApi.Migrations
{
    [DbContext(typeof(BlContext))]
    [Migration("20190428182111_AddalfaMigration3")]
    partial class AddalfaMigration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlfaBank.WebApi.Model.CardDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.Property<string>("CardName")
                        .IsRequired();

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CardType");

                    b.Property<DateTime>("DtOpenCard");

                    b.Property<int>("UserDbId");

                    b.HasKey("Id");

                    b.HasAlternateKey("CardNumber");

                    b.HasAlternateKey("CardNumber", "CardName");

                    b.HasIndex("UserDbId");

                    b.ToTable("CardsDb");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 0m,
                            CardName = "CardName",
                            CardNumber = "6271190189011743",
                            CardType = 0,
                            DtOpenCard = new DateTime(2019, 4, 28, 21, 20, 54, 366, DateTimeKind.Local).AddTicks(3046),
                            UserDbId = 1
                        });
                });

            modelBuilder.Entity("AlfaBank.WebApi.Model.TransactionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardDbId");

                    b.Property<string>("CardFromNumber");

                    b.Property<string>("CardToNumber");

                    b.Property<DateTime>("DateTime");

                    b.Property<decimal>("Sum");

                    b.HasKey("Id");

                    b.HasIndex("CardDbId");

                    b.HasIndex("DateTime");

                    b.ToTable("TransactionsDb");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardDbId = 1,
                            CardFromNumber = "6271190189011743",
                            CardToNumber = "6271190189011743",
                            DateTime = new DateTime(2019, 4, 28, 21, 20, 54, 367, DateTimeKind.Local).AddTicks(3886),
                            Sum = 10m
                        });
                });

            modelBuilder.Entity("AlfaBank.WebApi.Model.UserDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("Firstname");

                    b.Property<string>("Surname");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasAlternateKey("UserName");

                    b.ToTable("UsersDb");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Firstname = "Firstname",
                            Surname = "surname",
                            UserName = "iocsha"
                        });
                });

            modelBuilder.Entity("AlfaBank.WebApi.Model.CardDb", b =>
                {
                    b.HasOne("AlfaBank.WebApi.Model.UserDb", "Users")
                        .WithMany()
                        .HasForeignKey("UserDbId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AlfaBank.WebApi.Model.TransactionDb", b =>
                {
                    b.HasOne("AlfaBank.WebApi.Model.CardDb", "Cards")
                        .WithMany()
                        .HasForeignKey("CardDbId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
