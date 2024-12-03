﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebShopApi.Data;

#nullable disable

namespace WebShopApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241203085803_Update2")]
    partial class Update2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClothesItemOrder", b =>
                {
                    b.Property<Guid>("ClothesItemsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrdersId")
                        .HasColumnType("uuid");

                    b.HasKey("ClothesItemsId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("ClothesItemOrder");
                });

            modelBuilder.Entity("WebShopApi.Models.ClothesItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClothesTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClothesTypeId");

                    b.ToTable("ClothesItems");
                });

            modelBuilder.Entity("WebShopApi.Models.ClothesType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClothesTypes");
                });

            modelBuilder.Entity("WebShopApi.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("HasDiscount")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("TotalSpent")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebShopApi.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ClothesItemOrder", b =>
                {
                    b.HasOne("WebShopApi.Models.ClothesItem", null)
                        .WithMany()
                        .HasForeignKey("ClothesItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebShopApi.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebShopApi.Models.ClothesItem", b =>
                {
                    b.HasOne("WebShopApi.Models.ClothesType", "ClothesType")
                        .WithMany("ClothesItems")
                        .HasForeignKey("ClothesTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClothesType");
                });

            modelBuilder.Entity("WebShopApi.Models.Order", b =>
                {
                    b.HasOne("WebShopApi.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WebShopApi.Models.ClothesType", b =>
                {
                    b.Navigation("ClothesItems");
                });

            modelBuilder.Entity("WebShopApi.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
