using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealApp.Models.Models;
using MealApp.Services;
using MeatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public IndexModel(
            IProductRepository productRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        [BindProperty]
        public IEnumerable<ProductDTO> ProductsDTO { get; set; }
        public IActionResult OnGet()
        {
            var products = productRepository.GetAllProducts();
            ProductsDTO = mapper.Map<IEnumerable<ProductDTO>>(products);
            return Page();
        }
    }
}
