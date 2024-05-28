﻿// <auto-generated />
using System;
using JewelryProductionOrder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JewelryProductionOrder.Models.ProductionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProductionRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 5, 28, 14, 47, 16, 325, DateTimeKind.Local).AddTicks(1035)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 5, 28, 14, 47, 16, 325, DateTimeKind.Local).AddTicks(1054)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 5, 28, 14, 47, 16, 325, DateTimeKind.Local).AddTicks(1057)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
