﻿// <auto-generated />
using System;
using Masa.EShop.Service.Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Masa.EShop.Service.Catalog.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    partial class CatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.12");

            modelBuilder.Entity("Masa.BuildingBlocks.Dispatcher.IntegrationEvents.Logs.IntegrationEventLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("TEXT")
                        .HasColumnName("RowVersion");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimesSent")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "EventId", "RowVersion" }, "IX_EventId_Version");

                    b.HasIndex(new[] { "State", "ModificationTime" }, "IX_State_MTime");

                    b.HasIndex(new[] { "State", "TimesSent", "ModificationTime" }, "IX_State_TimesSent_MTime");

                    b.ToTable("IntegrationEventLog", (string)null);
                });

            modelBuilder.Entity("Masa.EShop.Service.Catalog.Domain.Aggregates.CatalogBrand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Creator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Modifier")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CatalogBrand", (string)null);
                });

            modelBuilder.Entity("Masa.EShop.Service.Catalog.Domain.Aggregates.CatalogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Creator")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxStockThreshold")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Modifier")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureFileName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("RestockThreshold")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("_catalogBrandId")
                        .HasColumnType("TEXT")
                        .HasColumnName("CatalogBrandId");

                    b.Property<int>("_catalogTypeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CatalogTypeId");

                    b.HasKey("Id");

                    b.HasIndex("_catalogBrandId");

                    b.HasIndex("_catalogTypeId");

                    b.ToTable("Catalog", (string)null);
                });

            modelBuilder.Entity("Masa.EShop.Service.Catalog.Domain.Aggregates.CatalogType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CatalogType", (string)null);
                });

            modelBuilder.Entity("Masa.EShop.Service.Catalog.Domain.Aggregates.CatalogItem", b =>
                {
                    b.HasOne("Masa.EShop.Service.Catalog.Domain.Aggregates.CatalogBrand", "CatalogBrand")
                        .WithMany()
                        .HasForeignKey("_catalogBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Masa.EShop.Service.Catalog.Domain.Aggregates.CatalogType", "CatalogType")
                        .WithMany()
                        .HasForeignKey("_catalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogBrand");

                    b.Navigation("CatalogType");
                });
#pragma warning restore 612, 618
        }
    }
}
