using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product DeleteProduct(int id);
        Product GetProduct(int id);
        Product UpdateProduct(Product product);
        IEnumerable<Product> SearchProduct(string searchTerm);
    }
}
