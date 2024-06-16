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
    [Migration("20240616083605_changeSeed")]
    partial class changeSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GemstoneMaterialSet", b =>
                {
                    b.Property<int>("GemstonesId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialSetsId")
                        .HasColumnType("int");

                    b.HasKey("GemstonesId", "MaterialSetsId");

                    b.HasIndex("MaterialSetsId");

                    b.ToTable("GemstoneMaterialSet");
                });

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

            modelBuilder.Entity("JewelryProductionOrder.Models.Gemstone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Gemstones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Diamond",
                            Price = 200000m,
                            Weight = 0m
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 6, 16, 15, 36, 4, 220, DateTimeKind.Local).AddTicks(8298),
                            Description = "9999Gold for the material and 1 carat diamond for everyday where",
                            Name = "Diamond Necklace",
                            ProductionRequestId = 1,
                            Status = ""
                        });
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

                    b.HasKey("Id");

                    b.HasIndex("MaterialSetId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gold",
                            Price = 1000m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Silver",
                            Price = 200m
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

                    b.Property<int?>("QuotationRequestId")
                        .HasColumnType("int");

                    b.Property<int?>("SalesStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DesignStaffId");

                    b.HasIndex("ProductionStaffId");

                    b.HasIndex("QuotationRequestId");

                    b.HasIndex("SalesStaffId");

                    b.ToTable("ProductionRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 6, 16, 15, 36, 4, 220, DateTimeKind.Local).AddTicks(8096),
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 6, 16, 15, 36, 4, 220, DateTimeKind.Local).AddTicks(8107),
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

                    b.Property<int>("JewelryId")
                        .HasColumnType("int");

                    b.Property<decimal>("LaborPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialSetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalesStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("JewelryId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("MaterialSetId");

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

            modelBuilder.Entity("GemstoneMaterialSet", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.Gemstone", null)
                        .WithMany()
                        .HasForeignKey("GemstonesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryProductionOrder.Models.MaterialSet", null)
                        .WithMany()
                        .HasForeignKey("MaterialSetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.HasOne("JewelryProductionOrder.Models.QuotationRequest", "QuotationRequest")
                        .WithMany()
                        .HasForeignKey("QuotationRequestId");

                    b.HasOne("JewelryProductionOrder.Models.User", "SalesStaff")
                        .WithMany()
                        .HasForeignKey("SalesStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");

                    b.Navigation("DesignStaff");

                    b.Navigation("ProductionStaff");

                    b.Navigation("QuotationRequest");

                    b.Navigation("SalesStaff");
                });

            modelBuilder.Entity("JewelryProductionOrder.Models.QuotationRequest", b =>
                {
                    b.HasOne("JewelryProductionOrder.Models.Jewelry", "Jewelry")
                        .WithMany()
                        .HasForeignKey("JewelryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.HasOne("JewelryProductionOrder.Models.User", "SalesStaff")
                        .WithMany()
                        .HasForeignKey("SalesStaffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Jewelry");

                    b.Navigation("Manager");

                    b.Navigation("MaterialSet");

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
#pragma warning restore 612, 618
        }
    }
}
