﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pizza_byte.api.Persistence;

#nullable disable

namespace pizza_byte.api.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    partial class PizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("pizza_byte.api.Models.PizzaByte", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<DateTime?>("CompletedDateTime")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "completedDateTime");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "createdDateTime");

                    b.Property<string>("Crust")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "crust");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "lastModifiedDateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "price");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "size");

                    b.Property<string>("Toppings")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "toppings");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
