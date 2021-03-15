﻿// <auto-generated />
using System;
using MealApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MealApp.Services.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MealApp.Models.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DietName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("MealApp.Models.DietDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<int>("Kcal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DietId");

                    b.ToTable("DayDiets");
                });

            modelBuilder.Entity("MealApp.Models.DietDayMeals", b =>
                {
                    b.Property<int>("DietDayId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfMeal")
                        .HasColumnType("int");

                    b.HasKey("DietDayId", "MealId");

                    b.HasIndex("MealId");

                    b.ToTable("DayDietMeals");
                });

            modelBuilder.Entity("MealApp.Models.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("MealApp.Models.MealProduct", b =>
                {
                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
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

                    b.Property<int>("Kcal")
                        .HasColumnType("int");

                    b.Property<string>("MealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfMeal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("MeatApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Kcal")
                        .HasColumnType("int");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityUnit")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MealApp.Models.DietDay", b =>
                {
                    b.HasOne("MealApp.Models.Diet", "Diet")
                        .WithMany("Days")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("MealApp.Models.DietDayMeals", b =>
                {
                    b.HasOne("MealApp.Models.DietDay", "DayDiet")
                        .WithMany("DayDietMeals")
                        .HasForeignKey("DietDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeatApp.Models.Meal", "Meal")
                        .WithMany("DayDietMeals")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayDiet");

                    b.Navigation("Meal");
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

            modelBuilder.Entity("MeatApp.Models.Product", b =>
                {
                    b.HasOne("MealApp.Models.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MealApp.Models.Diet", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("MealApp.Models.DietDay", b =>
                {
                    b.Navigation("DayDietMeals");
                });

            modelBuilder.Entity("MealApp.Models.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MeatApp.Models.Meal", b =>
                {
                    b.Navigation("DayDietMeals");

                    b.Navigation("MealProducts");
                });

            modelBuilder.Entity("MeatApp.Models.Product", b =>
                {
                    b.Navigation("MealProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
