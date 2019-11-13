﻿// <auto-generated />
using System;
using LagerSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LagerSystem.Migrations
{
    [DbContext(typeof(StorageContext))]
    [Migration("20191113072003_palletsList")]
    partial class palletsList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LagerSystem.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PalletId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("LagerSystem.Models.Pallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("Pallets");
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

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PalletId");

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

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("LagerSystem.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfRacks")
                        .HasColumnType("int");

                    b.Property<string>("StorageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("LagerSystem.Models.Item", b =>
                {
                    b.HasOne("LagerSystem.Models.Pallet", null)
                        .WithMany("Items")
                        .HasForeignKey("PalletId");
                });

            modelBuilder.Entity("LagerSystem.Models.Pallet", b =>
                {
                    b.HasOne("LagerSystem.Models.Storage", null)
                        .WithMany("Pallets")
                        .HasForeignKey("StorageId");
                });

            modelBuilder.Entity("LagerSystem.Models.Position", b =>
                {
                    b.HasOne("LagerSystem.Models.Pallet", "Pallet")
                        .WithMany()
                        .HasForeignKey("PalletId");

                    b.HasOne("LagerSystem.Models.Rack", null)
                        .WithMany("Positions")
                        .HasForeignKey("RackId");
                });

            modelBuilder.Entity("LagerSystem.Models.Rack", b =>
                {
                    b.HasOne("LagerSystem.Models.Storage", null)
                        .WithMany("Racks")
                        .HasForeignKey("StorageId");
                });
#pragma warning restore 612, 618
        }
    }
}
