using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Services
{
    public class SQLTypeOfMealRepository : ITypeOfMealRepository
    {
        private readonly AppDbContext dbContext;

        public SQLTypeOfMealRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TypeOfMeal AddType(TypeOfMeal typeOfMeal)
        {
            dbContext.Add(typeOfMeal);
            dbContext.SaveChanges();
            return typeOfMeal;
        }

        public TypeOfMeal DeleteType(int id)
        {
            TypeOfMeal typeOfMeal = dbContext.TypeOfMeals.Find(id);
            if(typeOfMeal != null)
            {
                dbContext.Remove(typeOfMeal);
                dbContext.SaveChanges();
            }
            return typeOfMeal;
        }

        public IEnumerable<TypeOfMeal> GetAllTypes()
        {
            return dbContext.TypeOfMeals.OrderBy(type=>type.Order);
        }

        public TypeOfMeal GetType(int id)
        {
            return dbContext.TypeOfMeals.Find(id);
        }

        public TypeOfMeal UpdateType(TypeOfMeal typeOfMeal)
        {
            var updatedType = dbContext.TypeOfMeals.Attach(typeOfMeal);
            updatedType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return typeOfMeal;
        }
    }
}
