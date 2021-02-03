using MealApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Services
{
    public class SQLDietRepository : IDietRepository
    {
        private readonly AppDbContext dbContext;

        public SQLDietRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Diet AddDiet(Diet diet)
        {
            dbContext.Add(diet);
            dbContext.SaveChanges();
            return diet;
        }

        public Diet DeleteDiet(int id)
        {
            var diet = dbContext.Diets.Find(id);
            if (diet != null)
            {
                dbContext.Remove(diet);
                dbContext.SaveChanges();
            }
            return diet;
        }

        public List<Diet> GetAllDiets()
        {
            return dbContext.Diets.Include(a => a.Days).ToList();
        }

        public Diet GetDiet(int id)
        {
            return dbContext.Diets
                .Include(d => d.Days)
                .ThenInclude(ddm=>ddm.DayDietMeals)
                .ThenInclude(m=>m.Meal)
                .Where(b=>b.Id==id).FirstOrDefault();
        }
    }
}
