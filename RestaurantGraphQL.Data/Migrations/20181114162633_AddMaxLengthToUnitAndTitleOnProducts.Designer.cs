﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RestaurantGraphQL.Data.Migrations
{
    [DbContext(typeof(ProductsDbContext))]
    [Migration("20181114162633_AddMaxLengthToUnitAndTitleOnProducts")]
    partial class AddMaxLengthToUnitAndTitleOnProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RestaurantGraphQL.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RestaurantGraphQL.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int?>("CoverId");

                    b.Property<double>("Stock");

                    b.Property<string>("Title")
                        .HasMaxLength(255);

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CoverId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RestaurantGraphQL.Core.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("RestaurantGraphQL.Core.Models.Product", b =>
                {
                    b.HasOne("RestaurantGraphQL.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RestaurantGraphQL.Core.Models.ProductImage", "Cover")
                        .WithMany()
                        .HasForeignKey("CoverId");
                });

            modelBuilder.Entity("RestaurantGraphQL.Core.Models.ProductImage", b =>
                {
                    b.HasOne("RestaurantGraphQL.Core.Models.Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}