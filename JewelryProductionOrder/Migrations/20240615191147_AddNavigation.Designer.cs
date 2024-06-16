﻿// <auto-generated />
using System;
using JewelryProductionOrder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JewelryProductionOrder.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240615191147_AddNavigation")]
    partial class AddNavigation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JewelryProductionOrder.Models.Delivery", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("SalesStaffId")
                        .HasColumnType("int");

                    b.Property<int>("JewelryId")
                        .HasColumnType("int");

                    b.Property<int>("WarrantyCardId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId", "SalesStaffId", "JewelryId", "WarrantyCardId");

                    b.HasIndex("JewelryId");

                    b.HasIndex("SalesStaffId");

                    b.HasIndex("WarrantyCardId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.Jewelry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaterialSetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionRequestId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductionStaffId")
                        .HasColumnType("int");

                    b.Property<int?>("SalesStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MaterialSetId");

                    b.HasIndex("ProductionRequestId");

                    b.HasIndex("ProductionStaffId");

                    b.HasIndex("SalesStaffId");

                    b.ToTable("Jewelries");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.JewelryDesign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("DesignFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DesignStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JewelryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionRequestId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DesignStaffId");

                    b.HasIndex("JewelryId");

                    b.HasIndex("ProductionRequestId");

                    b.HasIndex("ProductionStaffId");

                    b.ToTable("JewelryDesigns");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MaterialSetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialSetId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gold",
                            Price = 1000m,
                            Type = "Metal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Silver",
                            Price = 200m,
                            Type = "Metal"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Diamond",
                            Price = 200000m,
                            Type = "Gemstone"
                        });
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.MaterialSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MaterialSets");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.MaterialSetMaterial", b =>
                {
                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialSetId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaterialId", "MaterialSetId");

                    b.HasIndex("MaterialSetId");

                    b.ToTable("MaterialSetsMaterials");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalesStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SalesStaffId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.ProductionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("DesignStaffId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductionStaffId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SalesStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DesignStaffId");

                    b.HasIndex("ProductionStaffId");

                    b.HasIndex("SalesStaffId");

                    b.ToTable("ProductionRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 6, 16, 2, 11, 46, 410, DateTimeKind.Local).AddTicks(849),
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 6, 16, 2, 11, 46, 410, DateTimeKind.Local).AddTicks(861),
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.QuotationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("LaborPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialSetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionRequestId")
                        .HasColumnType("int");

                    b.Property<int>("SalesStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("MaterialSetId");

                    b.HasIndex("ProductionRequestId")
                        .IsUnique();

                    b.HasIndex("SalesStaffId");

                    b.ToTable("QuotationRequests");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Staff"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Staff",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.WarrantyCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("JewelryId")
                        .HasColumnType("int");

                    b.Property<int>("SalesStaffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("JewelryId")
                        .IsUnique();

                    b.HasIndex("SalesStaffId");

                    b.ToTable("WarrantyCards");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.Delivery", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.Jewelry", "Jewelry")
                        .WithMany()
                        .HasForeignKey("JewelryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.User", "SalesStaff")
                        .WithMany()
                        .HasForeignKey("SalesStaffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.WarrantyCard", "WarrantyCard")
                        .WithMany()
                        .HasForeignKey("WarrantyCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Jewelry");

                    b.Navigation("SalesStaff");

                    b.Navigation("WarrantyCard");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.Jewelry", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JewelryProductionOrder.Models.MaterialSet", "MaterialSet")
                        .WithMany()
                        .HasForeignKey("MaterialSetId");

                    b.HasOne("JewelryProductionOrder.Models.ProductionRequest", "ProductionRequest")
                        .WithMany()
                        .HasForeignKey("ProductionRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.User", "ProductionStaff")
                        .WithMany()
                        .HasForeignKey("ProductionStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JewelryProductionOrder.Models.User", "SalesStaff")
                        .WithMany()
                        .HasForeignKey("SalesStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");

                    b.Navigation("MaterialSet");

                    b.Navigation("ProductionRequest");

                    b.Navigation("ProductionStaff");

                    b.Navigation("SalesStaff");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.JewelryDesign", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.User", "DesignStaff")
                        .WithMany()
                        .HasForeignKey("DesignStaffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.Jewelry", "Jewelry")
                        .WithMany()
                        .HasForeignKey("JewelryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.ProductionRequest", "ProductionRequest")
                        .WithMany()
                        .HasForeignKey("ProductionRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.User", "ProductionStaff")
                        .WithMany()
                        .HasForeignKey("ProductionStaffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("DesignStaff");

                    b.Navigation("Jewelry");

                    b.Navigation("ProductionRequest");

                    b.Navigation("ProductionStaff");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.Material", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.MaterialSet", null)
                        .WithMany("Materials")
                        .HasForeignKey("MaterialSetId");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.MaterialSetMaterial", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.MaterialSet", "MaterialSet")
                        .WithMany("MaterialSetMaterials")
                        .HasForeignKey("MaterialSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("MaterialSet");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.Post", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.User", "SalesStaff")
                        .WithMany()
                        .HasForeignKey("SalesStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesStaff");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.ProductionRequest", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JewelryProductionOrder.Models.User", "DesignStaff")
                        .WithMany()
                        .HasForeignKey("DesignStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JewelryProductionOrder.Models.User", "ProductionStaff")
                        .WithMany()
                        .HasForeignKey("ProductionStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JewelryProductionOrder.Models.User", "SalesStaff")
                        .WithMany()
                        .HasForeignKey("SalesStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");

                    b.Navigation("DesignStaff");

                    b.Navigation("ProductionStaff");

                    b.Navigation("SalesStaff");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.QuotationRequest", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.MaterialSet", "MaterialSet")
                        .WithMany()
                        .HasForeignKey("MaterialSetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.ProductionRequest", "ProductionRequest")
                        .WithOne("QuotationRequest")
                        .HasForeignKey("JewelryProductionOrder.Models.QuotationRequest", "ProductionRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.User", "SalesStaff")
                        .WithMany()
                        .HasForeignKey("SalesStaffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("MaterialSet");

                    b.Navigation("ProductionRequest");

                    b.Navigation("SalesStaff");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.User", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.WarrantyCard", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.Jewelry", "Jewelry")
                        .WithOne("WarrantyCard")
                        .HasForeignKey("JewelryProductionOrder.Models.WarrantyCard", "JewelryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.User", "SalesStaff")
                        .WithMany()
                        .HasForeignKey("SalesStaffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Jewelry");

                    b.Navigation("SalesStaff");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.Jewelry", b =>
                {
                    b.Navigation("WarrantyCard");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.MaterialSet", b =>
                {
                    b.Navigation("MaterialSetMaterials");

                    b.Navigation("Materials");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.ProductionRequest", b =>
                {
                    b.Navigation("QuotationRequest");
                });
#pragma warning restore 612, 618
        }
    }
}