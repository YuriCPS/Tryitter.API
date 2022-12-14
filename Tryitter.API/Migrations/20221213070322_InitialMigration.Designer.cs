﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tryitter.API.Data;

#nullable disable

namespace Tryitter.API.Migrations
{
    [DbContext(typeof(TryitterDbContext))]
    [Migration("20221213070322_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tryitter.API.Data.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fundamentos"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Front-end"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Back-end"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ciencia da Computação"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Beyond"
                        });
                });

            modelBuilder.Entity("Tryitter.API.Data.Tweet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Esté é o primeiro tweet do Tryitter",
                            CreatedAt = new DateTime(2022, 12, 13, 4, 3, 22, 473, DateTimeKind.Local).AddTicks(9548),
                            UpdatedAt = new DateTime(2022, 12, 13, 4, 3, 22, 473, DateTimeKind.Local).AddTicks(9557),
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Content = "Olá, mundo!",
                            CreatedAt = new DateTime(2022, 12, 13, 4, 3, 22, 473, DateTimeKind.Local).AddTicks(9559),
                            UpdatedAt = new DateTime(2022, 12, 13, 4, 3, 22, 473, DateTimeKind.Local).AddTicks(9559),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Tryitter.API.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Administrador do Tryitter",
                            Email = "admin@email.com.br",
                            FirstName = "Admin",
                            LastName = "Tryitter",
                            ModuleId = 5,
                            Password = "admin123",
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Criador do Tryitter",
                            Email = "yuri@email.com.br",
                            FirstName = "Yuri",
                            LastName = "Carvalho",
                            ModuleId = 5,
                            Password = "yuri123",
                            UserName = "Yuri"
                        });
                });

            modelBuilder.Entity("Tryitter.API.Data.Tweet", b =>
                {
                    b.HasOne("Tryitter.API.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tryitter.API.Data.User", b =>
                {
                    b.HasOne("Tryitter.API.Data.Module", "Module")
                        .WithMany("Users")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("Tryitter.API.Data.Module", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
