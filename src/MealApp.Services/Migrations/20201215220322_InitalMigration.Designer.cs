﻿// <auto-generated />
using System;
using MealApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MealApp.Services.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201215220322_InitalMigration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MealApp.Models.MealProduct", b =>
                {
                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("MealId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("MealProducts");
                });

            modelBuilder.Entity("MeatApp.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("MeatApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("KcalInUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MeatApp.Models.TypeOfMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfMeals");
                });

            modelBuilder.Entity("MealApp.Models.MealProduct", b =>
                {
                    b.HasOne("MeatApp.Models.Meal", "Meal")
                        .WithMany("MealProducts")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeatApp.Models.Product", "Product")
                        .WithMany("MealProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MeatApp.Models.Meal", b =>
                {
                    b.HasOne("MeatApp.Models.TypeOfMeal", "Type")
                        .WithMany("Meals")
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("MeatApp.Models.Meal", b =>
                {
                    b.Navigation("MealProducts");
                });

            modelBuilder.Entity("MeatApp.Models.Product", b =>
                {
                    b.Navigation("MealProducts");
                });

            modelBuilder.Entity("MeatApp.Models.TypeOfMeal", b =>
                {
                    b.Navigation("Meals");
                });
#pragma warning restore 612, 618
        }
    }
}
