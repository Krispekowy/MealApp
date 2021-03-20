using MealApp.Models;
using MealApp.Models.Enums;
using MeatApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Services
{
    public class SQLMealRepository : IMealRepository
    {
        private readonly AppDbContext dbContext;

        public SQLMealRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Meal AddMeal(Meal meal)
        {
            dbContext.Add(meal);
            dbContext.SaveChanges();
            return meal;
        }

        public Meal DeleteMeal(int id)
        {
            Meal meal = dbContext.Meals.Find(id);
            if (meal != null)
            {
                dbContext.Remove(meal);
                dbContext.SaveChanges();
            }
            return meal;
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return dbContext.Meals;
        }

        public Meal GetMeal(int id)
        {
            return dbContext.Meals
                .Include(x => x.MealProducts)
                .FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Meal> MealByType(int typeId)
        {
            //var query = from meal in dbContext.Meals where meal.TypeOfMeal == (TypesOfMeal)typeId select meal;

            return dbContext.Meals.Where(a => a.TypeOfMeal == (TypesOfMeal)typeId).ToList();
            
            //return query;
        }

        public IEnumerable<Meal> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return dbContext.Meals;
            }
            return dbContext.Meals.Where(m => m.MealName.Contains(searchTerm) ||
                                              Enum.GetNames(typeof(TypesOfMeal)).Contains(searchTerm));
        }

        public Meal UpdateMeal(Meal updatedMeal)
        {
            var existingMeal = dbContext.Meals.Where(m => m.Id == updatedMeal.Id).Include(c => c.MealProducts).SingleOrDefault();

            if (existingMeal != null)
            {
                // Update parent
                dbContext.Entry(existingMeal).CurrentValues.SetValues(updatedMeal);

                // Delete children
                foreach (var existingMealProduct in existingMeal.MealProducts)
                {
                    if (!updatedMeal.MealProducts.Any(c => c.MealId == existingMealProduct.MealId && c.ProductId == existingMealProduct.ProductId))
                        dbContext.MealProducts.Remove(existingMealProduct);
                }

                // Update and Insert children
                foreach (var newOrUpdateMealProduct in updatedMeal.MealProducts)
                {
                    var existingMealProduct = existingMeal.MealProducts
                        .Where(c => c.MealId == newOrUpdateMealProduct.MealId && c.MealId != default(int) && c.ProductId == newOrUpdateMealProduct.ProductId && c.ProductId != default(int))
                        .SingleOrDefault();

                    if (existingMealProduct != null)
                        // Update child
                        dbContext.Entry(existingMealProduct).CurrentValues.SetValues(newOrUpdateMealProduct);
                    else
                    {
                        // Insert child
                        var newMealProduct = new MealProduct
                        {
                            MealId = newOrUpdateMealProduct.MealId,
                            ProductId = newOrUpdateMealProduct.ProductId,
                            Quantity = newOrUpdateMealProduct.Quantity
                        };
                        existingMeal.MealProducts.Add(newMealProduct);
                    }
                }

                dbContext.SaveChanges();
                return updatedMeal;
            }
            return updatedMeal;
        }
    }
}
