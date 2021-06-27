﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopBridge.API.Models;

namespace ShopBridge.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210618110839_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopBridge.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "OnePlus CE 5G Mobile",
                            Name = "OnePlus CE 5G",
                            Price = 27999.00m
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Moto G 5G Mobile",
                            Name = "Moto G 5G",
                            Price = 21999.00m
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Samsung M42 5G Mobile",
                            Name = "Samsung M42 5G",
                            Price = 22999.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}