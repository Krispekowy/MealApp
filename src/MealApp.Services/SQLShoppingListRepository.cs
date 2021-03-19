using MealApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Services
{
    public class SQLShoppingListRepository : IShoppingListRepository
    {
        private readonly AppDbContext dbContext;

        public SQLShoppingListRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ShoppingListDTO> GetShoppingList(List<ShoppingDayDTO> shoppingDays)
        {
            var allProducts = (from dd in dbContext.DayDiets
                        select new { dd.Id } into day
                        join ddm in dbContext.DayDietMeals on day.Id equals ddm.DietDayId
                        join mp in dbContext.MealProducts on ddm.MealId equals mp.MealId
                        select new { mp.ProductId, mp.Quantity, day.Id } into pid
                        join p in dbContext.Products on pid.ProductId equals p.Id
                        select new { pid.Id, p.ProductName, pid.ProductId, pid.Quantity } into data //, p.CategoryId
                        //join c in dbContext.ProductCategories on data.CategoryId equals c.Id
                        select new {data.Id, data.ProductId, data.ProductName, data.Quantity}) //, data.CategoryId, c.Name
                       .ToList();

            //var shoppingList = allProducts
            //    .Where(a => shoppingDays.Select(b => b.DayId).Contains(a.Id))
            //    .GroupBy(a => new { Category = a.CategoryId })
            //    .Select(grpCat => new ShoppingListDTO()
            //    {
            //        Category = grpCat.First().Name,
            //        Products = grpCat
            //        .GroupBy(p => p.ProductId)
            //        .Select(p => new ProductsToBuyDTO()
            //        {
            //            Product = p.First().ProductName,
            //            Quantity = (int)p.Sum(q => q.Quantity)*4
            //        })
            //        .ToList()
            //    }).ToList();
            return null; // shoppingList;
        }
    }
}
