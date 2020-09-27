﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts.Contexts;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200926112653_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mmu.Mlh.TestingExtensions.FakeDataAccess.Areas.Entities.Address", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("IndividualId")
                        .HasColumnType("bigint");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IndividualId");

                    b.ToTable("Address","Core");
                });

            modelBuilder.Entity("Mmu.Mlh.TestingExtensions.FakeDataAccess.Areas.Entities.Individual", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Individual","Core");
                });

            modelBuilder.Entity("Mmu.Mlh.TestingExtensions.FakeDataAccess.Areas.Entities.Street", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Street","Core");
                });

            modelBuilder.Entity("Mmu.Mlh.TestingExtensions.FakeDataAccess.Areas.Entities.Address", b =>
                {
                    b.HasOne("Mmu.Mlh.TestingExtensions.FakeDataAccess.Areas.Entities.Individual", null)
                        .WithMany("Addresses")
                        .HasForeignKey("IndividualId");
                });

            modelBuilder.Entity("Mmu.Mlh.TestingExtensions.FakeDataAccess.Areas.Entities.Street", b =>
                {
                    b.HasOne("Mmu.Mlh.TestingExtensions.FakeDataAccess.Areas.Entities.Address", null)
                        .WithMany("Streets")
                        .HasForeignKey("AddressId");
                });
#pragma warning restore 612, 618
        }
    }
}