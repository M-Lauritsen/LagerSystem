﻿// <auto-generated />
using System;
using LagerSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LagerSystem.Migrations
{
    [DbContext(typeof(StorageContext))]
    partial class StorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LagerSystem.Models.Pallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RackPosition")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pallets");
                });

            modelBuilder.Entity("LagerSystem.Models.PalletItems", b =>
                {
                    b.Property<int>("StockItemId")
                        .HasColumnType("int");

                    b.Property<int>("PalletId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("StockItemId", "PalletId");

                    b.HasIndex("PalletId");

                    b.ToTable("PalletItems");
                });

            modelBuilder.Entity("LagerSystem.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("PalletId")
                        .HasColumnType("int");

                    b.Property<int?>("RackId")
                        .HasColumnType("int");

                    b.Property<string>("RackPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PalletId")
                        .IsUnique()
                        .HasFilter("[PalletId] IS NOT NULL");

                    b.HasIndex("RackId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("LagerSystem.Models.Rack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("LagerSystem.Models.StockItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StockItems");
                });

            modelBuilder.Entity("LagerSystem.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("LagerSystem.Models.PalletItems", b =>
                {
                    b.HasOne("LagerSystem.Models.Pallet", "Pallet")
                        .WithMany("PalletItems")
                        .HasForeignKey("PalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LagerSystem.Models.StockItem", "StockItem")
                        .WithMany("PalletItems")
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LagerSystem.Models.Position", b =>
                {
                    b.HasOne("LagerSystem.Models.Pallet", "Pallet")
                        .WithOne("Position")
                        .HasForeignKey("LagerSystem.Models.Position", "PalletId");

                    b.HasOne("LagerSystem.Models.Rack", "Rack")
                        .WithMany("Positions")
                        .HasForeignKey("RackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LagerSystem.Models.Rack", b =>
                {
                    b.HasOne("LagerSystem.Models.Storage", "Storage")
                        .WithMany("Racks")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
