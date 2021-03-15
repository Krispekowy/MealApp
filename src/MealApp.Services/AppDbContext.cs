using MealApp.Models;
using MealApp.Models.Entity;
using MeatApp.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MealApp.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many relationship
            modelBuilder.Entity<MealProduct>()
                .HasKey(mp => new { mp.MealId, mp.ProductId });
            modelBuilder.Entity<MealProduct>()
                .HasOne(mp => mp.Meal)
                .WithMany(m => m.MealProducts)
                .HasForeignKey(mp => mp.MealId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MealProduct>()
                .HasOne(mp => mp.Product)
                .WithMany(m => m.MealProducts)
                .HasForeignKey(mp => mp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DietDayMeals>()
                .HasKey(ddm => new { ddm.DietDayId, ddm.MealId });
            modelBuilder.Entity<DietDayMeals>()
                .HasOne(ddm => ddm.DayDiet)
                .WithMany(dd => dd.DayDietMeals)
                .HasForeignKey(ddm => ddm.DietDayId);
            modelBuilder.Entity<DietDayMeals>()
                .HasOne(ddm => ddm.Meal)
                .WithMany(m => m.DayDietMeals)
                .HasForeignKey(ddm => ddm.MealId);

            //one to many relationships
            modelBuilder.Entity<DietDay>()
                .HasOne(d => d.Diet)
                .WithMany(dd => dd.Days)
                .HasForeignKey(d => d.DietId);
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId);

            //Do usunięcia jeśli stworzone zostanie zapytanie do bazy bezpośrednio w kodzie
            //modelBuilder.Entity<v_ShoppingList>()
            //    .ToTable("v_ShoppingLists");
            //modelBuilder.Entity<v_ShoppingList>()
            //    .HasKey(t => t.ProduktId);
                
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MealProduct> MealProducts { get; set; }
        public DbSet<DietDayMeals> DayDietMeals { get; set; }
        public DbSet<DietDay> DayDiets { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Category> ProductCategories { get; set; }

    }
}
