﻿// <auto-generated />
using Ecommerce.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.DAL.Migrations
{
    [DbContext(typeof(EcommerecContext))]
    [Migration("20230922183654_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce.DAL.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Home Appliances"
                        });
                });

            modelBuilder.Entity("Ecommerce.DAL.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Smartphone",
                            Price = 599.99m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Laptop",
                            Price = 999.99m,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Name = "T-Shirt",
                            Price = 19.99m,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Name = "Washing Machine",
                            Price = 449.99m,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Name = "Headphones",
                            Price = 89.99m,
                            Quantity = 150
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Name = "Jeans",
                            Price = 39.99m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Name = "Refrigerator",
                            Price = 799.99m,
                            Quantity = 40
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Name = "Tablet",
                            Price = 299.99m,
                            Quantity = 75
                        });
                });

            modelBuilder.Entity("Ecommerce.DAL.Product", b =>
                {
                    b.HasOne("Ecommerce.DAL.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ecommerce.DAL.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
