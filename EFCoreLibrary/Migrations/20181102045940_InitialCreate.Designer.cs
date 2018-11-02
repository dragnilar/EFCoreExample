﻿// <auto-generated />
using EF6Library.EFClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreLibrary.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20181102045940_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDomain.Models.Armor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArmorName")
                        .HasMaxLength(1000);

                    b.Property<string>("ArmorType")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Armors");
                });

            modelBuilder.Entity("EFDomain.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharacterName")
                        .HasMaxLength(1000);

                    b.Property<string>("CharacterType")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("EFDomain.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemName")
                        .HasMaxLength(1000);

                    b.Property<string>("ItemType")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("EFDomain.Models.Monster", b =>
                {
                    b.Property<int>("MonsterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MonsterName")
                        .HasMaxLength(1000);

                    b.Property<string>("MonsterType")
                        .HasMaxLength(250);

                    b.HasKey("MonsterId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("EFDomain.Models.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("WeaponName")
                        .HasMaxLength(1000);

                    b.Property<string>("WeaponType")
                        .HasMaxLength(250);

                    b.HasKey("WeaponId");

                    b.ToTable("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}