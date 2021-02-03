using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Services
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public SQLProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Product AddProduct(Product product)
        {
            dbContext.Add(product);
            dbContext.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
            Product product = dbContext.Products.Find(id);
            if(product != null)
            {
                dbContext.Remove(product);
                dbContext.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products;
        }

        public Product GetProduct(int id)
        {
            return dbContext.Products.Find(id);
        }

        public IEnumerable<Product> SearchProduct(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return dbContext.Products;
            }
            return dbContext.Products.Where(p => p.ProductName.Contains(searchTerm) ||
                                              p.Unit.Contains(searchTerm));
        }

        public Product UpdateProduct(Product updatedProduct)
        {
            var product = dbContext.Products.Attach(updatedProduct);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return updatedProduct;
        }
    }
}
